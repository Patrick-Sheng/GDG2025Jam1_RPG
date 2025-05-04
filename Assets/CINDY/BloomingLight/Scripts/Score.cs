using System;
using TMPro;
using UnityEngine;

public sealed class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    public event Action OnWin;

    private int _score;

    public int ScoreCount {
        get => _score;

        set {
            if (_score == value) return;

            _score = value;

            scoreText.SetText($"Score: {_score}");

            if (_score >= 50) {
                OnWin?.Invoke(); // Fire win event
            }
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() => Instance = this;
}
