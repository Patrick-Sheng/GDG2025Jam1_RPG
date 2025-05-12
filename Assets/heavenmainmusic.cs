using UnityEngine;

public class heavenmainmusic : MonoBehaviour
{
    private bool playing;
    public AudioSource source;

    // Update is called once per frame
    void Update()
    {
        if (StaticManager.godDiologueEnd && playing == false)
        {
            playing = true;
            source.Play();
        }
    }
}
