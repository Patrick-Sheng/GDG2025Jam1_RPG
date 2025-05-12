using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI tutorialText;
    public GameObject winScreen;
    public BirdScript bird;

    public AudioClip winSound;
    public AudioSource audioSource;

    void Start()
    {
        scoreText.text = "Score: " + playerScore.ToString();
        tutorialText.text = "Press Space to fly your bird.";
        tutorialText.gameObject.SetActive(true);
    }

    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.W))
        //{
          //  tutorialText.gameObject.SetActive(false);
            //showWinScreen();
       // }
    }

    //[ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();

        if (playerScore >= 20)
        {
            showWinScreen();
        }

    }


    public void gameOver() {
        gameOverScreen.SetActive(true);
    }

    public void showWinScreen()
    {
        StaticManager.birdwon = true;
        if (winSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(winSound);
        }
        winScreen.SetActive(true);
        bird.birdIsAlive = false;  // Prevents further flying
    }
}
