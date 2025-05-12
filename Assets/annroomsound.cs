using UnityEngine;
using UnityEngine.Audio;

public class annroomsound : MonoBehaviour
{
    public AudioSource source;
    private void Start()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("HeavenMusic") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("HeavenMusic"));
        }

        GameObject[] sounds = GameObject.FindGameObjectsWithTag("AnnRoomSound");

        if (sounds.Length > 1)
        {
            for (int i = 1; i < sounds.Length; i++)
            {
                Destroy(sounds[i]);
            }
        }


    }
}
