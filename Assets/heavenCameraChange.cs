using UnityEngine;

public class heavenCameraChange : MonoBehaviour
{
    public cameramovementscript cammovescr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "Top")
            {
                cammovescr.TopArea();
            }
            //else if (gameObject.name == "Bottom")
            //{
            //    cammovescr.BottomArea();
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "Top")
            {
                
                cammovescr.BottomArea();
            }

        }
    }


}
