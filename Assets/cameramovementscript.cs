using UnityEngine;

public class cameramovementscript : MonoBehaviour
{
    public GameObject Player;

    private bool BottomAreaBool;


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
        if (BottomAreaBool == true)
        {
            print("this is running");
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,   Player.transform.position.y, -1.85f);
        }
    }
}
