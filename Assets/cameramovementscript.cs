using UnityEngine;

public class cameramovementscript : MonoBehaviour
{
    public GameObject Player;

    private bool BottomAreaBool;
    private bool endside;
    private void Start()
    {
        BottomArea();
    }
    public void ENDSIDE()
    {
        endside = true;
    }
    public void ENDSIDEOUT()
    {
        endside = false;
    }
    public void TopArea()
    {
        BottomAreaBool = false;
    }
    public void BottomArea()
    {
        BottomAreaBool = true;
    }
    void Update()
    {
        if (StaticManager.LayingDownRightnow)
        {

        }
        else
        {
            if (BottomAreaBool == true)
            {
                if (endside == true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, Player.transform.position.y, -1.85f);
                }
                else
                {
                    gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1.85f);
                }

            }
            else
            {
                if (endside == true)
                {
                    gameObject.transform.position = gameObject.transform.position;
                }
                else
                {
                    gameObject.transform.position = new Vector3(Player.transform.position.x, gameObject.transform.position.y, -1.85f);

                }
            }
        }
        

    }
}
