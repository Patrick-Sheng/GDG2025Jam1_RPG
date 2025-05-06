using UnityEngine;

public class cameraControllerGateRoom : MonoBehaviour
{
    public GameObject Player;

    private bool fixedposbool;
    public void fixedpos()
    {
        fixedposbool = true;
    }

    public void nonFixedPos()
    {
        fixedposbool = false;
    }

    private void Update()
    {
        if (fixedposbool == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.85f);

        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, Player.transform.position.y, -1.85f);

        }
    }
}
