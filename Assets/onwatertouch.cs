using UnityEngine;
using UnityEngine.SceneManagement;

public class onwatertouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Droplet")
        {
            StaticManager.bucketend = true;
            StaticManager.bucketwin = false ;
            SceneManager.LoadScene("WordleRoom");
        }
    }
}
