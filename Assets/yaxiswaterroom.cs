using UnityEngine;

public class yaxiswaterroom : MonoBehaviour
{
    public cameraMovementALL cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.YAxisFreeWater();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.YAxisFreeWaternomore();
        }
    }
}
