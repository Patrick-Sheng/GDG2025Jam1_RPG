using UnityEngine;

public class ArcadeReturn : MonoBehaviour
{
    public GameObject cam;
    public GameObject Player;
    public cameramovementscript CamScript;
    public TextAsset winLoseDialogueInk;

    public GameObject CoinCanvas;
    void Start()
    {




        if (StaticManager.YouLoseArcade || StaticManager.YouWinArcade)
        {
            if (StaticManager.YouWinArcade == true)
            {
                StaticManager.NumDollars = StaticManager.NumDollars + 21;
                CoinCanvas.SetActive(true);
            }


            CamScript.BottomArea();
            cam.transform.position = new Vector3(20.2456f, 3.29596f, -1.85f);
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
