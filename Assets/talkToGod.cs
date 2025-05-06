using UnityEngine;

public class talkToGod : MonoBehaviour
{
    public GameObject god;
    private bool gobig;

    private Animator GodAnimator;
    public Camera cam;
    public TextAsset godspeaks;
    void Start()
    {
        if (StaticManager.talkedtogood == false)
        {
            StaticManager.talkedtogood = true;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 1f, cam.transform.position.z);
            cam.orthographicSize = 2.8f;
            DialogueManager.GetInstance().EnterDialogueMode(godspeaks);


        }
    }
    private void Update()
    {
        if (StaticManager.godDiologueEnd)
        {
            if (gobig == false)
            {
                gobig = true;
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 1f, cam.transform.position.z);
            }

            if (cam.orthographicSize < 5.97f)
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
