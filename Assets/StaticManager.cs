<<<<<<< HEAD
using UnityEditor.Build;
=======
using Unity.VisualScripting;
using UnityEditor;
>>>>>>> origin/main
using UnityEngine;
using UnityEngine.InputSystem;

public class StaticManager : MonoBehaviour
{
<<<<<<< HEAD
    public static bool PlayerDead;
    public static bool carHit;

<<<<<<< HEAD
    public static int numberOfCorrect;
=======
    // public static bool indio;
    public static bool carmove; 

    public static bool canOpenGate;
=======
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
>>>>>>> origin/main

    public static bool talkedToOldMan;

>>>>>>> 1eb4687061b60c07074a15637837d6fb1ebf44ae
    public static bool resettrigger;
    public static string nextScene;

<<<<<<< HEAD
    public static void UpdateVariable(string varName, string value) {
      bool result;

      switch(varName)
      {
        case "talkedToOldMan":
          if(bool.TryParse(value, out result))
            talkedToOldMan = result;
          break;
        case "canOpenGate":
          if(bool.TryParse(value, out result))
            canOpenGate = result;
          break;
      }
      
      print($"Updated {varName} to {value}");
=======
    public static int licked;
    public static bool CanLick;
    public static bool licked6times;
    public static bool Plus1Dollar;


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




>>>>>>> origin/main
    }
}
