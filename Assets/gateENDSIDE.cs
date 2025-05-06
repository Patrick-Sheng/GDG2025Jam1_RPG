using UnityEngine;

public class gateENDSIDE : MonoBehaviour
{
    public cameraControllerGateRoom cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.fixedpos();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.nonFixedPos();
        }
    }
}
