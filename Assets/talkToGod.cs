using UnityEngine;

public class talkToGod : MonoBehaviour
{
    public GameObject god;

    private Animator GodAnimator;
    public Camera cam;
    public TextAsset godspeaks;
    void Start()
    {
        if (StaticManager.talkedtogood == false)
        {
            StaticManager.talkedtogood = true;
            cam.orthographicSize = 3.25f;
            DialogueManager.GetInstance().EnterDialogueMode(godspeaks);


        }
    }
    private void Update()
    {
        if (StaticManager.godDiologueEnd)
        {
            if (cam.orthographicSize < 8.45f)
            {
                cam.orthographicSize = cam.orthographicSize + 0.1f;

            }
            else
            {
                god.GetComponent<Animator>().Play("run away");
                StaticManager.godDiologueEnd = false;
            }
        }
    }

}
