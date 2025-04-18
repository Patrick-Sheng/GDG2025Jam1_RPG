using UnityEngine;

public class ArcadeReturn : MonoBehaviour
{
    public GameObject Player;
    public cameramovementscript CamScript;
    public TextAsset winLoseDialogueInk;
    void Start()
    {




        if (StaticManager.YouLoseArcade || StaticManager.YouWinArcade)
        {

            CamScript.BottomArea();

            Player.transform.position = gameObject.transform.position;

            string knot = null;

            if (StaticManager.YouWinArcade) knot = "arcade_win";
            if (StaticManager.YouLoseArcade) knot = "arcade_lose";

            StaticManager.YouWinArcade = false;
            StaticManager.YouLoseArcade = false;

            if (knot != null)
            {
                DialogueManager.GetInstance().EnterAtKnot(winLoseDialogueInk, knot);
            }



        }
    }


}
