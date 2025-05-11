using UnityEngine;
using UnityEngine.UIElements;

public class stickmantellsyougodisbad : MonoBehaviour
{
    public GameObject guysprite;
    public TextAsset GuyDiologue1;
    private bool timerstart;
    private float timer;
    void Start()
    {
        if (StaticManager.fadeaway != true)
        {

            timerstart = true;
            timer = 1f;
            

        }
    }
    private void Update()
    {
        
        if (timerstart == true)
        {
            
            timer = timer - Time.deltaTime;
            if (timer < 0f)
            {
                guysprite.SetActive(true);
                DialogueManager.GetInstance().EnterDialogueMode(GuyDiologue1);
                timerstart = false;
                timer = 1f;
                
            }
        }
    }

}
