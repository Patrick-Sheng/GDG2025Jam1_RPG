using UnityEngine;

public class cameraMovementALL : MonoBehaviour
{
    public GameObject Player;
    private bool outbounds;
    private bool whiteaxisfree;
    public void YAxisFreeWater()
    {
        whiteaxisfree = true;
    }
    public void YAxisFreeWaternomore()
    {
        whiteaxisfree = false;
    }
    public void OutSideOfBounds()
    {
        outbounds = true;
    }
    public void InsideOfBounds()
    {
        outbounds = false;
    }
    void Update()
    {
        if (gameObject.name == "hallwaycam")
        {
            if (outbounds)
            {

                {
                    gameObject.transform.position = new Vector3(Player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
        if (gameObject.name == "fountainroom")
        {
            if (outbounds)
            {
                {
                    if (whiteaxisfree == false)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);

                    }
                    else
                    {
                        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);
                    }
                }
            }
            else
            {
                if (whiteaxisfree == false)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);


                }
                else
                {
                    gameObject.transform.position = new Vector3(Player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
        }

    }
}
