using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterGameManager : MonoBehaviour
{

    public UnityEngine.UI.Text scoreText; // Reference to the UI Text component for displaying the score

    public GameObject gameOverPanel;

    private int score;

    private bool isGameOver;

    public void IncreaseScore()
    {
        if (score >= 10) // Check if the score is already at the maximum
        {
            StaticManager.bucketend = true;
            StaticManager.bucketwin = true;
            SceneManager.LoadScene("WordleRoom");
            isGameOver = true; // Set the game over flag to true
            Debug.Log("Maximum score reached!"); // Log a message to the console
            return; // Exit the method if the maximum score is reached
        }
        score++;
        scoreText.text = score.ToString(); // Update the UI Text component with the new score
    }
}
