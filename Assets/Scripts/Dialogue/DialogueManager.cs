using TMPro;
using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using System.Net.NetworkInformation;



public class DialogueManager : MonoBehaviour
{

    public AudioSource typing;

    [SerializeField] private float typingSpeed = 0.04f;
     
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private TextMeshProUGUI displayNameText;

    [SerializeField] Animator portraitAnimator;

    private Animator layoutAnimator;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    


    
    
    private TextMeshProUGUI[] choicesText;





    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";




    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }


    private static DialogueManager instance;

    private bool canContinueToNextLine = false;


    private Coroutine displayLineCoroutine;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one DIalogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }


    }

    private void Update()
    {
        //return when dialogue isnt playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //currentStory.currentChoices.Count == 0
        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.C))
        {
            ContinueStory();
        }



    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //LayoutRebuilder.ForceRebuildLayoutImmediate(dialoguePanel.GetComponent<RectTransform>());

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;

        displayNameText.text = "???";
        portraitAnimator.Play("default");

        layoutAnimator.Play("default");

        //dialoguePanel.SetActive(false);
        dialoguePanel.SetActive(true);

        //StartCoroutine(RefreshLayout());

        Canvas.ForceUpdateCanvases();



        //layoutAnimator.Play("default", -1, 0f); // The extra parameters ensure it plays from start
        //layoutAnimator.Update(0f); // Force immediate update





        ContinueStory();




    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        //FindObjectOfType<DialogueTrigger>().ResetTrigger();
        //StaticManager.resettrigger = true;

        StartCoroutine(CoroutineExample());




    }
    private IEnumerator CoroutineExample()
    {
        Debug.Log("Coroutine started!");

        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.2f);
        StaticManager.resettrigger = false;
        Debug.Log("Coroutine ended after 0.5 seconds!");
    }
    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //dialogueText.text = currentStory.Continue();

            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            HandleTags(currentStory.currentTags);
            CheckForVariableUpdate();


            //dialogueText.text = nextLine;

            

            StartCoroutine(RefreshUI());

            

            //handle tags


        }
        else
        {
            ExitDialogueMode();
        }
    }


    private IEnumerator RefreshUI()
    {
        // Wait for end of frame to ensure all UI elements are active
        yield return new WaitForEndOfFrame();

        // Force all necessary updates
        dialogueText.ForceMeshUpdate();
        LayoutRebuilder.ForceRebuildLayoutImmediate(dialogueText.rectTransform);
        if (dialogueText.transform.parent != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogueText.transform.parent.GetComponent<RectTransform>());
        }
        Canvas.ForceUpdateCanvases();
    }


    private IEnumerator DisplayLine(string line)
    {
        //empty the dialogue text
        dialogueText.text = "";

        HideChoices();
        


        canContinueToNextLine = false;

        foreach(char letter in line.ToCharArray())
        {

            // Maybe set a boolean to true when a key is pressed and say if the boolean is true do this shit
            
            if (Input.GetKey(KeyCode.X))
            {
                dialogueText.text = line;
                break;
                // set the boolean to false here
            }
            typing.pitch = Random.Range(0.9f, 1.1f);
            typing.PlayOneShot(typing.clip);


            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        DisplayChoices();

        canContinueToNextLine = true;
    }
         

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        // loop thought each tag 
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag Could Not Be parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came but isnt being handled" + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More Choices Were given than the current UI system can support");
        }

        int index = 0;

        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private void ForceImmediateRebuild()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(dialogueText.rectTransform);
        dialogueText.ForceMeshUpdate();
    }
    private IEnumerator SelectFirstChoice()

    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

    }
    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
    }

    private void CheckForVariableUpdate() {
      foreach(string tag in currentStory.currentTags)
        {
            if(tag.StartsWith("UPDATE_VAR:"))
            {
                print("Found it!");
                ProcessVariableUpdate(tag);
            }
        }
    }

    private void ProcessVariableUpdate(string tag) {
        // Remove the "UPDATE_VAR:" prefix
        string content = tag.Substring(11);
        
        // Split into variable name and value
        string[] parts = content.Split(',');
        if(parts.Length == 2)
        {
            string varName = parts[0];
            string varValue = parts[1];
            
            // Update the static manager
            StaticManager.UpdateVariable(varName, varValue);
        }
    }

}
