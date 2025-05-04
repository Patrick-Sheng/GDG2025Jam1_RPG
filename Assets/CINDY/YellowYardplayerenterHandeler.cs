using UnityEngine;

public class YellowYardplayerenterHandeler : MonoBehaviour
{
    
    public GameObject Player;
    public GameObject bottom;
    public GameObject topleft;
    void Start()
    {
        if (StaticManager.goingfrombirdroom){
            StaticManager.goingfrombirdroom = false;
            Player.transform.position = bottom.transform.position;
        }
        
        if (StaticManager.gofromgraveyard){
            StaticManager.gofromgraveyard = false;
            Player.transform.position = topleft.transform.position;
        }
    }

}
