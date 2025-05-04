using UnityEngine;

public class laydownmanagerscript : MonoBehaviour
{

    public GameObject cam;
    private Transform CamTransform;

    public GameObject LayDownSprite;
    public GameObject Player;
    public GameObject REALplayer;

    public DialogueManager dM;
    private bool dmend;
    private bool movedback;
    void Update()
    {
        if (StaticManager.layDown)
        {
            if (movedback == false)
            {
                REALplayer.transform.position = new Vector2 (REALplayer.transform.position.x - 0.2f, REALplayer.transform.position.y);
                movedback = true;

            }

            if (dmend == false)
            {
                dmend = true;
                dM.ContinueStory();
            }
            StaticManager.LayingDownRightnow = true;

            Player.SetActive(false);
            LayDownSprite.SetActive(true);

            if (Input.GetKeyDown(KeyCode.C))
            {
                movedback = false;
                Player.SetActive(true);
                StaticManager.LayingDownRightnow = false;


                LayDownSprite.SetActive(false);
                StaticManager.layDown = false;
                dmend = false;
            }

        }
    }
}
