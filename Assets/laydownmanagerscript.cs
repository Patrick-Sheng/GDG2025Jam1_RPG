using UnityEngine;

public class laydownmanagerscript : MonoBehaviour
{
    public GameObject spawn;

    public GameObject cam;
    private Transform CamTransform;

    public GameObject LayDownSprite;
    public GameObject Player;
    public GameObject REALplayer;

    public DialogueManager dM;
    private bool dmend;
    private bool movedback;

    private bool timerstart;
    private float timer = 0.4f;
    void Update()
    {
        if (StaticManager.layDown)
        {
            timer = timer - Time.deltaTime;

            REALplayer.SetActive(false);
            //if (movedback == false)
            //{
            //    REALplayer.transform.position = spawn.transform.position;
            //    movedback = true;

            //}

            if (dmend == false)
            {
                dmend = true;
                dM.ContinueStory();
            }
            StaticManager.LayingDownRightnow = true;

            Player.SetActive(false);
            LayDownSprite.SetActive(true);


            if (timer < 0)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    timer = 0.4f;
                    movedback = false;
                    REALplayer.SetActive(true);
                    StaticManager.LayingDownRightnow = false;
                    REALplayer.transform.position = spawn.transform.position;

                    LayDownSprite.SetActive(false);
                    StaticManager.layDown = false;
                    dmend = false;
                }
            }
        }
    }
}
