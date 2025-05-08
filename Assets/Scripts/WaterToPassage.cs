using UnityEngine;

public class WaterToPassage : MonoBehaviour
{
    public Animator animator;         
    public string triggerName = "Transform";
    private bool doneallthestuff;
    public GameObject cam;
    public GameObject newCam;
    private bool starttimer;
    private float timer = 1f;
    public DialogueManager DialogueManager;

    private void Update()
    {
        if (StaticManager.changePond && doneallthestuff == false && Input.GetKeyDown(KeyCode.C))
        {
            DialogueManager.ContinueStory();
            print("thisishappening");
            doneallthestuff = true;
            PlayTransformation();
            cam.SetActive(false);
            newCam.SetActive(true);
            starttimer = true;

        }

        if (starttimer == true)
        {
            timer = timer - Time.deltaTime;
            if (timer < 0)
            {
                cam.SetActive(true);
                newCam.SetActive(false);
            }
        }
    }
    public void PlayTransformation()
    {
        if (animator != null)
        {
            animator.Play("pondtogate");
        }
        else
        {
            Debug.LogWarning("Animator not assigned on " + gameObject.name);
        }
    }
}

