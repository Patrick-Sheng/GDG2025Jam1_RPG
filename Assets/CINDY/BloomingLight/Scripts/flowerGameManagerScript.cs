using UnityEngine;
using UnityEngine.SceneManagement;

public class flowerGameManagerScript : MonoBehaviour
{
    public GameObject dogbone;
    public GameObject Player;
    public GameObject GameEndSpawn;
    private void Start()
    {
        if (StaticManager.graveYard && StaticManager.onetimeGraveyard == false)
        {
            StaticManager.onetimeGraveyard = true;
            Player.transform.position = GameEndSpawn.transform.position;
        }
    }
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
