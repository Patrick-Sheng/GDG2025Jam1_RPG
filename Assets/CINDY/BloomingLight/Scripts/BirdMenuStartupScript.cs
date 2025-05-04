using UnityEngine;

public class BirdMenuStartupScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip birdStartSound;

    private static bool hasPlayed = false;

    void Start()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            if (audioSource != null && birdStartSound != null)
            {
                audioSource.PlayOneShot(birdStartSound);
                Debug.Log("Played bird start sound (session first time)");
            }
        }
    }
}


