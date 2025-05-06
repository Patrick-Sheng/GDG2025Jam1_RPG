using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxscript : MonoBehaviour
{
    float timer = 0.8f;
    void Update()
    {
        if (StaticManager.givenbone)
        {

            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y);
            timer = timer - Time.deltaTime;

            if (timer < 0)
            {
                SceneManager.LoadScene("DogRoomTunnel");
            }
        }
        
    }
}
