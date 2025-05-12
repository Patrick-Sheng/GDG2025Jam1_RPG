using UnityEngine;

public class parkmoosicstop : MonoBehaviour
{
    public AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticManager.carmove)
        {
            source.Stop();
        }
    }
}
