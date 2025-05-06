using UnityEngine;

public class endSIDE : MonoBehaviour
{
    public cameramovementscript cammovescr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "ENDSIDE")
            {
                cammovescr.ENDSIDE();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "ENDSIDE")
            {
                cammovescr.ENDSIDEOUT();
            }

        }
    }
}
