using UnityEditor.U2D.Aseprite;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    private static readonly KeyCode[] SUPPORTED_KEYS = new KeyCode[] {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F,
        KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L,
        KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R,
        KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
        KeyCode.Y, KeyCode.Z,
    };

    private Row[] rows;

    private string[] solutions;
    private string[] validWords;
    private string word;

    // to keep track of which tile we are on - they start from 0, e.g. 0,0, 3,0
    private int rowIndex;
    private int columnIndex;

    [Header("States")]
    public Tile.State emptyState;
    public Tile.State occupiedState;
    public Tile.State correctState;
    public Tile.State wrongSpotState;
    public Tile.State incorrectState;

    [Header("UI")]
    public TextMeshProUGUI invalidWordText;
    public Button newWordButton;
    public Button tryAgainButton;


    private void Awake() {
        rows = GetComponentsInChildren<Row>();
    }

    private void Start() {
        LoadData();
        NewGame();
    }

    public void NewGame() {
        ClearBoard();
        SetRandomWord();
        enabled = true;
    }

    public void TryAgain() {
        ClearBoard();
        enabled  = true;
    }


    private void LoadData() {
        TextAsset textFile = Resources.Load("official_wordle_all") as TextAsset;
        validWords = textFile.text.Split('\n');

        textFile = Resources.Load("RPG_words") as TextAsset;
        solutions = textFile.text.Split('\n');
        
    }

    private void SetRandomWord() {
        word = solutions[Random.Range(0, solutions.Length)];
        // ensure lowercase as when we set tile to a letter its lowercase
        word = word.ToLower().Trim();
    }

    // when detecting input in unity, you do so in the update function
    private void Update()
    {
        Row currentRow = rows[rowIndex];
        

        // if backspace, set tile to null
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            // clamping the column index by the lower bound
            columnIndex = Mathf.Max(columnIndex - 1, 0);
            currentRow.tiles[columnIndex].SetLetter('\0');
            currentRow.tiles[columnIndex].SetState(emptyState);

            invalidWordText.gameObject.SetActive(false);
        }

        // if out of bounds, check if user submits row
        else if (columnIndex >= currentRow.tiles.Length) {
            // if user presses enter then submit row!
            if (Input.GetKeyDown(KeyCode.Return)) {
                SubmitRow(currentRow);
            }
        } else {
            for (int i = 0; i < SUPPORTED_KEYS.Length; i++) {

                if (Input.GetKeyDown(SUPPORTED_KEYS[i])) {
                    
                    // setting the letter to a specific tile
                    currentRow.tiles[columnIndex].SetLetter((char)SUPPORTED_KEYS[i]);
                    currentRow.tiles[columnIndex].SetState(occupiedState);
                    columnIndex++;
                    break;
                }
            }
        }

    }

    private void SubmitRow(Row row) {

        if (!isValidWord(row.word)) {
            invalidWordText.gameObject.SetActive(true);
            return;
        }

        string remaining = word;
        
        for (int i = 0; i < row.tiles.Length; i++) {
            Tile tile = row.tiles[i];

            if (tile.letter == word[i]) {

                tile.SetState(correctState);

                remaining = remaining.Remove(i, 1);
                remaining = remaining.Insert(i, " ");
            }
            else if (!word.Contains(tile.letter)) {
                tile.SetState(incorrectState);
            }
        }


        for (int i = 0; i < row.tiles.Length; i++) {
            Tile tile = row.tiles[i];

            if (tile.state != correctState && tile.state != incorrectState) {
                if (remaining.Contains(tile.letter)) {

                    tile.SetState(wrongSpotState);
                    
                    int index = remaining.IndexOf(tile.letter);
                    remaining = remaining.Remove(index, 1);
                    remaining = remaining.Insert(index, " ");
                }
                else {
                    tile.SetState(incorrectState);
                }
            }
        }
        // old simple solution that doesn't factor in edge cases:

        // for (int i = 0; i < row.tiles.Length; i++) {
        //     Tile tile = row.tiles[i];
        //     if (tile.letter == word[i]) {
        //         tile.SetState(correctState);
        //     } else if (word.Contains(tile.letter)) {
        //         tile.SetState(wrongSpotState);
        //     } else {
        //         tile.SetState(incorrectState);
        //     }
        // }

        if (HasWon(row)) {
            enabled = false;
        }

        rowIndex++;
        columnIndex = 0;

        if (rowIndex >= rows.Length) {
            enabled = false;
        }
    }

    private void ClearBoard() {
        for (int row = 0; row < rows.Length; row++) {
            for (int col = 0; col < rows[row].tiles.Length; col++) {
                rows[row].tiles[col].SetLetter('\0');
                rows[row].tiles[col].SetState(emptyState);
            }
        }

        rowIndex = 0;
        columnIndex = 0;
    }

    private bool isValidWord(string word) {
        for (int i = 0; i < validWords.Length; i++) {
            if (validWords[i] == word) {
                return true;
            }
        }

        return false;
    }

    private bool HasWon(Row row) {
        for (int i = 0; i < row.tiles.Length; i++) {
            if (row.tiles[i].state != correctState) {
                return false;
            }
        }

        return true;
    }

    private void OnEnable()
    {
        tryAgainButton.gameObject.SetActive(false);
        newWordButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        tryAgainButton.gameObject.SetActive(true);
        newWordButton.gameObject.SetActive(true);
    }


    // text file of words is in folder "Resources" as this folder is loaded at runtime in Unity
}
