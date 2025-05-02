using UnityEngine;

public class laydownmanagerscript : MonoBehaviour
{
    public GameObject LayDownSprite;
    public GameObject Player;

    public DialogueManager dM;
    private bool dmend;
    void Update()
    {
        if (StaticManager.layDown)
        {
            if (dmend == false)
            {
                dmend = true;
                dM.ContinueStory();
            }


            Player.SetActive(false);
            LayDownSprite.SetActive(true);

            if (Input.GetKeyDown(KeyCode.C))
            {
                Player.SetActive(true);
                LayDownSprite.SetActive(false);
                StaticManager.layDown = false;
                dmend = false;
            }

        }
    }
}
