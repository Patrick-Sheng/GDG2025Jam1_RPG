using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public class StaticManager : MonoBehaviour
{

    public static bool GODSHITDIDEND;
    public static bool stopforeva;

    public static bool PlacedAll;
    public static bool WonGame;
    public static bool onetimeGraveyard;
    public static bool onetimebirdspawn;
    public static bool winBirdgame;
    public static bool graveYard;


    public static bool fulltankmore;
    public static bool fullhandsfalse;

    public static bool fountaindone;
    public static bool FireHDone;



    public static bool pickUpWater;
    public static bool FishPlayed;
    public static bool takeBone;

    public static bool givenbone;
    public static bool hasbone;
    public static bool haswordleKey;
    public static bool bucketwin;
    public static bool bucketend;
    public static bool YellowToHall;

    public static bool wallCracked;
    public static int pushTimes;
    public static bool PlayerDead;
    public static bool carHit;

    public static bool pickedUpBone;
    public static bool pickedUpTruffle;
    public static bool pickedUpRuby;

    public static bool firstTime_pickedUpBone;
    public static bool firstTime_pickedUpTruffle;
    public static bool firstTime_pickedUpRuby;

    public static bool placedDogBone = false;
    public static bool placedTruffle = false;
    public static bool placedRuby = false;

    public static bool placedDogBoneOnTable = false;
    public static bool placedTruffleOnTable = false;
    public static bool placedRubyOnTable = false;

    public static bool goingFromMoleRoom1 = false;
    public static bool goingFromMoleRoom2 = false;
    public static bool goingFromMoleRoom3 = false;
    public static bool goingFromMoleRoom4 = false;

    public static bool goingFromGardenRoom = false;

    public static bool moleRoom1Visited;

    public static int currentInteractingStoneTable = 0;
    public static bool completedPressurePlatePuzzle;
    public static int numberOfCorrect;
    // public static bool indio;
    public static bool carmove; 

    public static bool canOpenGate;

    public static bool noguard;

    public static bool fromdoghall;
    public static bool fromgirlroom;
    public static bool enterWordle;
    // public static bool PlayerDead;
    // public static bool carHit;
    // public static int numberOfCorrect;
    // public static bool carmove;
    // public static bool canOpenGate;



    public static bool flowerWon;
    public static bool birdwon;
    public static bool flowerGameStart;
    public static bool birdGameStart;
    public static bool goingfrombirdroom;
    public static bool gofromgraveyard;
    public static bool LayingDownRightnow;
    public static bool godDiologueEnd;
    public static bool talkedtogood = false;

    // public static bool noguard;
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
    public static float NumDollars;
    public static bool YouWinArcade;
    public static bool YouLoseArcade;
    public static bool resettrigger;
    public static string nextScene;

    public static bool talkedToOldMan;
    // public static bool resettrigger;
    // public static string nextScene;

    public static int couchPosition;

    public static List<ItemEnum> inventory = new List<ItemEnum>();

    public static void UpdateVariable(string varName, string value) {
      bool result;
      int intResult;

      switch(varName)
      {
        case "talkedToOldMan":
          if(bool.TryParse(value, out result))
            talkedToOldMan = result;
            print($"Updated {varName} to {value}");
          break;
        case "canOpenGate":
          if(bool.TryParse(value, out result))
            canOpenGate = result;
            print($"Updated {varName} to {value}");
          break;
        case "pushTimes":
          if(int.TryParse(value, out intResult))
            pushTimes += intResult;
            UncoveringRuby uncoveringRubyInstance = FindObjectOfType<UncoveringRuby>();
            if (uncoveringRubyInstance != null)
            {
                uncoveringRubyInstance.UpdateImage();
            }
            else
            {
                Debug.LogError("UncoveringRuby instance not found in the scene.");
            }
            print($"Updated {varName} to {pushTimes}");
          break;
        case "pickedUpBone":
          if(bool.TryParse(value, out result))
            pickedUpBone = result;
            print($"Updated {varName} to {value}");
          break;
        case "pickedUpTruffle":
          if(bool.TryParse(value, out result))
            pickedUpTruffle = result;
            print($"Updated {varName} to {value}");
          break;
        case "pickedUpRuby":
          if(bool.TryParse(value, out result))
            pickedUpRuby = result;
            print($"Updated {varName} to {value}");
          break;
        case "placedDogBone":
          if(bool.TryParse(value, out result))
            placedDogBone = result;
            print($"Updated {varName} to {value}");
          break;
        case "placedTruffle":
          if(bool.TryParse(value, out result))
            placedTruffle = result;
            print($"Updated {varName} to {value}");
          break;
        case "placedRuby":
          if(bool.TryParse(value, out result))
            placedRuby = result;
            print($"Updated {varName} to {value}");
          break;
        case "currentInteractingStoneTable":
          if(int.TryParse(value, out intResult))
            currentInteractingStoneTable = intResult;
            print($"Updated {varName} to {currentInteractingStoneTable}");
          break;
      }
    }
    public static int licked;
    public static bool CanLick;
    public static bool licked6times;
    public static bool Plus1Dollar;

    public static bool FullHands;
    public static bool ponddone;
    public static int fulltank;
    private float smalltimer;
    public static bool changePond;

    public static bool thankyou;

    public static bool fadeaway;
    public static bool stickmangone;
    public static bool fadeaway2;
    public static bool stickmangone2;
    float dofulltalk;
    bool dofulltalkstart;

    float escHoldTime = 0f;
    float requiredHoldTime = 3f;

    public TextMeshProUGUI exitingText;

    public static bool tankisfull;
    // public static int couchPosition;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {

            escHoldTime += Time.deltaTime;
            Debug.Log("Esc hold time: " + escHoldTime);

            if (escHoldTime % 0.9f < 0.3f) {
                exitingText.text = "Exiting.";
            } else if (escHoldTime % 0.9f < 0.6f) {
                exitingText.text = "Exiting..";
            } else if (escHoldTime % 0.9f < 0.9f) {
                exitingText.text = "Exiting...";
            }

            if (escHoldTime >= requiredHoldTime) {
                QuitGame();
            }
        } else {
            exitingText.text = "";
            // Reset if the key is released before the hold time is reached
            escHoldTime = 0f;
        }

        if (dofulltalkstart)
        {
            dofulltalk = dofulltalk - Time.deltaTime;
            if (dofulltalk < 0)
            {
                fulltank = fulltank + 1;
                dofulltalkstart = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            print(fulltank);
        }

        if (fullhandsfalse)
        {
            fullhandsfalse = false;
            FullHands = false;
        }
        if (fulltankmore)
        {
            fulltankmore = false;
            dofulltalkstart = true;
            // ADD HERE
            dofulltalk = 0.1f;
            if (fulltank > 1)
            {
                tankisfull = true;
            }
        }


        if (pickUpWater)
        {
            FullHands = true;
            pickUpWater = false;
        }



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
            NumDollars = NumDollars - 11;
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



        if (licked >  10)
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
            NumDollars = NumDollars + 0.5f;
            Plus1Dollar = false;
        }




    }

    private void QuitGame()
    {
      #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
      #else
          Application.Quit();
      #endif
    }
}
