using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdGameManagerScript : MonoBehaviour
{

    void Update()
    {
        if (StaticManager.birdGameStart){
            SceneManager.LoadScene("MenuScene_Bird");
            StaticManager.birdGameStart = false;
        }
    }
}
