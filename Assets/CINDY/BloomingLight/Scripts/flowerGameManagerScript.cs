using UnityEngine;
using UnityEngine.SceneManagement;

public class flowerGameManagerScript : MonoBehaviour
{
    public GameObject dogbone;
    
    void Update()
    {
        if (StaticManager.birdwon == false)
        {
            if (GameObject.FindGameObjectWithTag("flowerKey") != null)
            {
                GameObject.FindGameObjectWithTag("flowerKey").SetActive(false);
            }
        }
        if (StaticManager.flowerGameStart){
            SceneManager.LoadScene("MenuScene_BloomingLight");
            StaticManager.flowerGameStart = false;
        }

        if (StaticManager.flowerWon) {
            StaticManager.hasbone = true; 
            dogbone.SetActive(true);
        }
    }
}
