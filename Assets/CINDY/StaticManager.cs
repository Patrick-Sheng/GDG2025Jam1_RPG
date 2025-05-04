using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    public static bool fromdoghall;
    public static bool fromgirlroom;
    public static bool enterWordle;
    public static bool PlayerDead;
    public static bool carHit;
    public static int numberOfCorrect;
    public static bool carmove;
    public static bool canOpenGate;



    public static bool flowerWon;
    public static bool birdwon;
    public static bool flowerGameStart;
    public static bool birdGameStart;
    public static bool goingfrombirdroom;
    public static bool gofromgraveyard;
    public static bool LayingDownRightnow;
    public static bool godDiologueEnd;
    public static bool talkedtogood = false;

    public static bool noguard;
    public static bool DisableGuardOnRoomEntry;
    public static bool justpancakerun;
    public static bool gatetoheaven;
    public static bool layDown;
    public static bool runaway;
    public static bool stealmoney;
    public static bool stealpancakes;
    public static bool hasmoney;
    public static bool Plus1Pancake;
    public static bool hasPancake;
    public static bool canbuypancake;
    public static int NumDollars;
    public static bool YouWinArcade;
    public static bool YouLoseArcade;
    public static bool resettrigger;
    public static string nextScene;
    public static int licked;
    public static bool CanLick;
    public static bool licked6times;
    public static bool Plus1Dollar;
    public static int couchPosition;
    private void Update()
    {





        if (NumDollars > 0)
        {
            hasmoney = true;
        }
        else
        {
            hasmoney = false;
        }



        if (Plus1Pancake)
        {
            NumDollars = NumDollars - 21;
            if (NumDollars < 0)
            {
                NumDollars = 0;
            }

            GameObject Pancakecanvas = GameObject.FindGameObjectWithTag("pancakeholder");
            foreach (Transform child in Pancakecanvas.transform)
                child.gameObject.SetActive(true);


            Plus1Pancake = false;
            hasPancake = true;
        }



        if (licked > 5)
        {
            licked6times = true;
        }
        if (Plus1Dollar)
        {
            GameObject Moneycanvas = GameObject.FindGameObjectWithTag("moneyholder");
            foreach (Transform child in Moneycanvas.transform)
                child.gameObject.SetActive(true);
            licked = 0;
            CanLick = false;
            licked6times = false;
            NumDollars++;
            Plus1Dollar = false;
        }




    }
}
