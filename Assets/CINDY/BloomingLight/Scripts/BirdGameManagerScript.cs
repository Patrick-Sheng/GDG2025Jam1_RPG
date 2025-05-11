using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdGameManagerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject winspawn;
    private void Start()
    {
        if (StaticManager.winBirdgame == true && StaticManager.onetimebirdspawn == false)
        {
            Player.transform.position = winspawn.transform.position;
            StaticManager.onetimebirdspawn = true;

        }
    }
    void Update()
    {
        if (StaticManager.birdGameStart){
            SceneManager.LoadScene("MenuScene_Bird");
            StaticManager.birdGameStart = false;
        }
    }
}
