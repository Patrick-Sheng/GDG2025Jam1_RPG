
using System;
using System.Collections.Generic;
using System.Linq;
using Task = System.Threading.Tasks.Task;
using UnityEngine;
using DG.Tweening;

public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }
    private bool _hasWon = false;

    [SerializeField] private GameObject winMessageUI;
    [SerializeField] private GameObject itemTextUI;


    [SerializeField] private AudioClip popSound;
    [SerializeField] private AudioClip winSound;

    [SerializeField] private AudioSource audioSource;

    public Row[] rows;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);

    private readonly List<Tile> _selection = new List<Tile>();

    private const float TweenDuration = 0.25f;

    private void Awake() => Instance = this;

    private void Update() {
        //if (!Input.GetKeyDown(KeyCode.A)) return;

        //foreach (var connectedTile in Tiles[0, 0].GetConnectedTiles()) {
            //connectedTile.icon.transform.DOScale(1.25f, TweenDuration).Play();
        //}

       // if(Input.GetKeyDown(KeyCode.W)) {
         //   Debug.Log($"Manual win triggered. Has won? {_hasWon}");
           // Score.Instance.ScoreCount = 50;
            // HandleWin();
        //}
    }

    private void Start() {

        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length];

        for (var y = 0; y < Height; y++) {
            for (var x = 0; x < Width; x++) {

                var tile = rows[y].tiles[x];

                tile.x = x;
                tile.y = y;

                tile.Item = ItemDatabase.Items[UnityEngine.Random.Range(0, ItemDatabase.Items.Length)];

                Tiles[x, y] = tile;
            }
        }

        Score.Instance.OnWin += HandleWin;
    }

    private async void HandleWin() {
        if (_hasWon) return; // Extra safety check
        Debug.Log("WIN condition triggered!");

        _hasWon = true; // Lock the game state
        //DOTween.KillAll(); // Kills all active tweens immediately
        audioSource.Stop(); // Stops all currently playing sounds from this source

        if (winMessageUI == null) {
            Debug.LogWarning("WinMessageUI is NULL");
            return;
        }

        if (winSound != null && audioSource != null) {
            audioSource.PlayOneShot(winSound);
            // wait until sound finishes before showing win text
            await Task.Delay((int)(winSound.length * 1000));
        }

        winMessageUI.SetActive(true);
        itemTextUI.SetActive(true);
        
        StaticManager.flowerWon = true;
    }



    public async void Select(Tile tile) {
        if (_hasWon) return; // Ignore input if game has been won

        if (!_selection.Contains(tile)) _selection.Add(tile);

        /*** this part is to disable swap between tiles that are not neighbours 
             
        ***/
        if (_selection.Count == 2) {
            var dx = Mathf.Abs(_selection[0].x - _selection[1].x);
            var dy = Mathf.Abs(_selection[0].y - _selection[1].y);

            if ((dx + dy) != 1) {
                Debug.Log("Tiles are not adjacent.");
                _selection.Clear();
                return;
            }
        }
   

        if (_selection.Count < 2) return;

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y}) and ({_selection[1].x}, {_selection[1].y})");
        
        await Swap(_selection[0], _selection[1]);

        if (CanPop()){
            Pop();
        } else {
            await Swap(_selection[0], _selection[1]);
        }
        _selection.Clear();
    }

    public async Task Swap(Tile tile1, Tile tile2) {

        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();

        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        var tile1Item = tile1.Item;
        
        tile1.Item = tile2.Item;
        tile2.Item = tile1Item;

    }


    private bool CanPop() {

        for (var y = 0; y < Height; y++) {
            for (var x = 0; x < Width; x++) {
                if (Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= 2) return true;
            }
        }
        return false;
    }

    private async void Pop()
    {
        if (_hasWon) return;

        bool foundMatches;

        do {
            foundMatches = false;

            for (var y = 0; y < Height; y++) {
                for (var x = 0; x < Width; x++) {
                    var tile = Tiles[x, y];
                    var connectedTiles = tile.GetConnectedTiles();

                    if (connectedTiles.Skip(1).Count() < 2) continue;

                    foundMatches = true;

                    var deflateSequence = DOTween.Sequence();

                    foreach (var connectedTile in connectedTiles) {
                        deflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.zero, TweenDuration));
                    }

                    audioSource.PlayOneShot(popSound);
                    Score.Instance.ScoreCount += connectedTiles.Count;

                    await deflateSequence.Play().AsyncWaitForCompletion();

                    var inflateSequence = DOTween.Sequence();

                    foreach (var connectedTile in connectedTiles) {
                        connectedTile.Item = ItemDatabase.Items[UnityEngine.Random.Range(0, ItemDatabase.Items.Length)];
                        inflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.one, TweenDuration));
                    }

                    await inflateSequence.Play().AsyncWaitForCompletion();
                }
            }

        } while (foundMatches);

        // AFTER all animations and loops are done
        if (Score.Instance.ScoreCount >= 20 && !_hasWon) {
            await Task.Delay(500); // Optional dramatic pause
            HandleWin();
        }
    }



    private void OnDestroy() {
        if (Score.Instance != null) {
            Score.Instance.OnWin -= HandleWin;
    }
    }
}
