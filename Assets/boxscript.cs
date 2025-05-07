using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxscript : MonoBehaviour
{
    float timer = 0.2f;
    
    void Update()
    {

        if (StaticManager.takeBone == true)
        {
            if (GameObject.FindGameObjectWithTag("bone") != null)
            {
                StaticManager.takeBone = false;
                Destroy(GameObject.FindGameObjectWithTag("bone"));
            }

            
        }


        if (StaticManager.givenbone)
        {
            
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y);
            timer = timer - Time.deltaTime;

            if (timer < 0)
            {

                SceneManager.LoadScene("DogRoomTunnel");
            }
        }
        
    }
}
