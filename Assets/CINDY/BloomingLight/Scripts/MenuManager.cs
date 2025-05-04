using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip flowerStartSound;
    public AudioClip birdStartSound;

    public void StartGame()
    {
        StartCoroutine(PlayClickThen(() => SceneManager.LoadScene("GameScene_BloomingLight")));
    }

    public void ExitGame()
    {
        StartCoroutine(PlayClickThen(() => SceneManager.LoadScene("Graveyard")));
        Debug.Log("Quit Game");
    }

    public void StartBirdGame()
    {
        StartCoroutine(PlayClickThen(() => SceneManager.LoadScene("GameScene_Bird")));
    }

       public void ExitBirdGame()
    {
        StartCoroutine(PlayClickThen(() => SceneManager.LoadScene("Birdroom")));
        Debug.Log("Quit Game");
    }

        public void GoToBirdMenu()
    {
        StartCoroutine(PlayClickThenBirdMenu());
    }

    private IEnumerator PlayClickThen(System.Action nextAction)
    {
        PlayClick();
        yield return new WaitForSeconds(clickSound.length); // Wait until sound finishes
        nextAction.Invoke();
    }


    public void RestartGame()
    {
        StartCoroutine(PlayClickThenReload());
    }

    public void GoToMenu()
    {
        StartCoroutine(PlayClickThenMenu());
    }

    private IEnumerator PlayClickThenReload()
    {
        PlayClick();
        yield return new WaitForSeconds(audioSource.clip.length); // wait for click sound to finish
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator PlayClickThenMenu()
    {
        PlayClick();
        yield return new WaitForSeconds(audioSource.clip.length); // wait for click sound to finish
        SceneManager.LoadScene("MenuScene_BloomingLight");
    }

    private IEnumerator PlayClickThenBirdMenu()
    {
        PlayClick();
        yield return new WaitForSeconds(audioSource.clip.length); // wait for click sound to finish
        SceneManager.LoadScene("MenuScene_Bird");
    }


    private void PlayClick()
    {
        Debug.Log("PlayClick triggered!");
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }


    private void Update() {
    if (Input.GetKeyDown(KeyCode.S)) {
        Debug.Log("Manually testing sound");
        PlayClick();
    }
    }
}