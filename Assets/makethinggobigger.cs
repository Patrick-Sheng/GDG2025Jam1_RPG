using UnityEngine;

public class makethinggobigger : MonoBehaviour
{
    public GameObject noise;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayMusic()
    {
        noise.SetActive(true);
    }

}
