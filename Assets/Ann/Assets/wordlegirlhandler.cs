using UnityEngine;
using UnityEngine.SceneManagement;

public class wordlegirlhandler : MonoBehaviour
{
    public cameraMovementALL came;

    public GameObject nexttogirl;
    public TextAsset YouWin;
    public GameObject Player;
    public GameObject keycanvas;
    public GameObject cam;
   

    private void Start()
    {
        if (StaticManager.bucketend)
        {
            if (StaticManager.bucketwin)
            {
                StaticManager.bucketend = false;
                StaticManager.bucketwin = false;
                Player.transform.position = nexttogirl.transform.position;
                cam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
                keycanvas.SetActive(true);
                StaticManager.haswordleKey = true;
                DialogueManager.GetInstance().EnterDialogueMode(YouWin);
                came.OutSideOfBounds();
                //enter diologue where shes like wow you won heres a key
            }
            else
            {
                came.OutSideOfBounds();
                StaticManager.bucketend = false;
                Player.transform.position = nexttogirl.transform.position;
                cam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10) ;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (StaticManager.enterWordle)
        {
            StaticManager.enterWordle = false;
            SceneManager.LoadScene("WaterGame");
        }



    }
}
