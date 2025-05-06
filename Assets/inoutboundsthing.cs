using UnityEngine;

public class inoutboundsthing : MonoBehaviour
{
    public cameraMovementALL cammovesc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cammovesc.InsideOfBounds();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cammovesc.OutSideOfBounds();
        }
    }
}
