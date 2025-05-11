using UnityEngine;

public class stickamn2 : MonoBehaviour
{
    public TextAsset GuyDiologue1;
    public GameObject guySprite;
    private float timer = 2f;
    private bool timerstart;

    void Start()
    {

    }
    private void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0 && timerstart == false && StaticManager.fadeaway2 != true)
        {
            DialogueManager.GetInstance().EnterDialogueMode(GuyDiologue1);
            guySprite.SetActive(true);
            timerstart = true;
        }
    }
}

