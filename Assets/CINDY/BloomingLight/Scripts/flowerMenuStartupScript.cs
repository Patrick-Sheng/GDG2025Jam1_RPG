using UnityEngine;

public class FlowerMenuStartup : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip flowerStartSound;

    private static bool hasPlayed = false;

    void Start()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            if (audioSource != null && flowerStartSound != null)
            {
                audioSource.PlayOneShot(flowerStartSound);
                Debug.Log("Played flower start sound (session first time)");
            }
        }
    }
}
