using UnityEngine;

public class cindygarden : MonoBehaviour
{
    private bool movecamera;
    public GameObject Player;
    public GameObject Camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            movecamera = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            movecamera = false;
        }

    }

    private void Update()
    {
        if (movecamera)
        {
            Camera.transform.position = new Vector3(Player.transform.position.x, Camera.transform.position.y, -10f);
        }
        
    }
}
