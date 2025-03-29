
using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private bool inputCooldown; // New flag

    private bool hasTriggered; // New flag to track if triggered


    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }



    private void Update()
    {
        
        //if (StaticManager.resettrigger)
        //{
        //    hasTriggered = false;
            
        //    StaticManager.resettrigger = false;
        //}

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);


            // chat gpt code (LOL)
            //if (playerInRange
            //&& !DialogueManager.GetInstance().dialogueIsPlaying
            //&& Input.GetKeyDown(KeyCode.C)
            //&& !inputCooldown)
            //{
            //    StartCoroutine(StartDialogue());
            //}

            // non chat gpt code
            //&& !inputCooldown
            if (Input.GetKeyDown(KeyCode.C) && StaticManager.resettrigger == false)
            {
                //StartCoroutine(InputCooldownRoutine());
                StaticManager.resettrigger = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
               //hasTriggered = true;

            }


        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    // non chat gpt code 

    private IEnumerator InputCooldownRoutine()
    {
        inputCooldown = true;
        yield return new WaitForSeconds(0.2f); // Adjust time as needed
        inputCooldown = false;
    }
    // chat gpt code (LOL)

    public void ResetTrigger()
    {
        
    }
    private IEnumerator StartDialogue()
    {
        hasTriggered = true;
        inputCooldown = true;
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        yield return new WaitForSeconds(0.5f); // Prevents rapid re-trigger
        inputCooldown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
