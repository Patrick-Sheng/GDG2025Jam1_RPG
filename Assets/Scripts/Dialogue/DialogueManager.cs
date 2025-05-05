using TMPro;
using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.NetworkInformation;
using System.Linq;



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




    public Story currentStory;

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
        //chat gpt code LOL

        // end of chat gpt code 

        //return when dialogue isnt playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //if (dialogueIsPlaying && !currentStory.canContinue && !currentStory.currentChoices.Any())
        //{
        //    ExitDialogueMode();
        //}

        //cgpt
        //if (dialogueIsPlaying &&
        //!currentStory.canContinue &&
        //!currentStory.currentChoices.Any() &&
        // canContinueToNextLine)       // wait until the line has fully printed
        //{
        //    ExitDialogueMode();
        //}

        //currentStory.currentChoices.Count == 0
        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.C))
        {
            ContinueStory();
        }



    }
    public void EnterAtKnot(TextAsset inkJSON, string knotName)
    {
        currentStory = new Story(inkJSON.text);
        currentStory.BindExternalFunction("canlickcone",() => StaticManager.CanLick);
        currentStory.BindExternalFunction("Licked6times", () => StaticManager.licked6times);
        currentStory.BindExternalFunction("canbuypancake", () => StaticManager.canbuypancake);
        currentStory.BindExternalFunction("boughtpancake", () => StaticManager.hasPancake);
        currentStory.BindExternalFunction("hasmoney", () => StaticManager.hasmoney);
        currentStory.BindExternalFunction("moneynumber", () => StaticManager.NumDollars);
        currentStory.BindExternalFunction("wallCracked", () => StaticManager.wallCracked);
    currentStory.BindExternalFunction("hasDogBone", (System.Func<object>)(() => StaticManager.inventory.Contains(ItemEnum.DOG_BONE)));
    currentStory.BindExternalFunction("hasTruffle", (System.Func<object>)(() => StaticManager.inventory.Contains(ItemEnum.TRUFFLE)));
    currentStory.BindExternalFunction("hasRuby", (System.Func<object>)(() => StaticManager.inventory.Contains(ItemEnum.RUBY)));



        currentStory.ChoosePathString(knotName);

        dialogueIsPlaying = true;

        // ��� UI boilerplate you had in EnterDialogueMode ���
        displayNameText.text = "???";
        portraitAnimator.Play("default");
        layoutAnimator.Play("default");
        dialoguePanel.SetActive(true);
        Canvas.ForceUpdateCanvases();
        // ������������������������������������������������

        ContinueStory();
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {

        //LayoutRebuilder.ForceRebuildLayoutImmediate(dialoguePanel.GetComponent<RectTransform>());

        //PUT VARAIBLE CHECKS HERE
        currentStory = new Story(inkJSON.text);
        currentStory.BindExternalFunction("canlickcone",() => StaticManager.CanLick);
        currentStory.BindExternalFunction("Licked6times", () => StaticManager.licked6times);
        currentStory.BindExternalFunction("canbuypancake", () => StaticManager.canbuypancake);
        currentStory.BindExternalFunction("boughtpancake", () => StaticManager.hasPancake);
        currentStory.BindExternalFunction("hasmoney", () => StaticManager.hasmoney);
        currentStory.BindExternalFunction("moneynumber", () => StaticManager.NumDollars);
        currentStory.BindExternalFunction("wallCracked", () => StaticManager.wallCracked);
    currentStory.BindExternalFunction("hasDogBone", (System.Func<object>)(() => StaticManager.inventory.Contains(ItemEnum.DOG_BONE)));
    currentStory.BindExternalFunction("hasTruffle", (System.Func<object>)(() => StaticManager.inventory.Contains(ItemEnum.TRUFFLE)));
    currentStory.BindExternalFunction("hasRuby", (System.Func<object>)(() => StaticManager.inventory.Contains(ItemEnum.RUBY)));

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

    public void ExitDialogueMode()
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
            //chat gpt told me to move this somewhere else 
            //HandleTags(currentStory.currentTags);


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

        if (currentStory.currentTags.Count > 0)
            HandleTags(currentStory.currentTags);

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

            if(tag.Trim() == "GoToArcadeRoom")
            {
                ExitDialogueMode();
                dialogueIsPlaying = false;
                dialoguePanel.SetActive(false);

                SceneManager.LoadScene("TestArcade");
                Debug.Log("niceTag has passed!");
                continue; // Skip to next tag
            }
            if (tag.Trim() == "canlick")
            {
                StaticManager.CanLick = true;
                continue;
            }
            if (tag.Trim() == "licked")
            {
                StaticManager.licked++;
                continue;
            }
            if (tag.Trim() == "plus1dollar")
            {
                StaticManager.Plus1Dollar = true;
                continue;
            }
            if (tag.Trim() == "plus1pancake")
            {
                StaticManager.Plus1Pancake = true;
                continue;
            }
            if (tag.Trim() == "stealpancakes")
            {
                StaticManager.stealpancakes = true;
                continue;
            }
            if (tag.Trim() == "stealmoney")
            {
                StaticManager.stealmoney = true;
                continue;
            }
            if (tag.Trim() == "runaway")
            {
                StaticManager.runaway = true;
                Debug.Log("runawaynow");
                continue;
            }
            if (tag.Trim() == "laydown")
            {
                StaticManager.layDown = true;
                Debug.Log("runawaynow");
                continue;
            }
            if (tag.Trim() == "justpancakerun")
            {
                StaticManager.justpancakerun = true;
                Debug.Log("runawaynow");
                continue;
            }
            if (tag.Trim() == "StartFlowerGame")
            {
                StaticManager.flowerGameStart = true;
                continue;
            }
            if (tag.Trim() == "StartBirdGame")
            {
                StaticManager.birdGameStart = true;
                continue;
            }
            if (tag.Trim() == "deleteKey")
            {
                StaticManager.birdwon = false;
                continue;
            }
            if (tag.Trim() == "GodDiolgueEnd")
            {
                StaticManager.godDiologueEnd = true;
                Debug.Log("runawaynow");
                continue;
            }
            if (tag.Trim() == "PlayWordle")
            {
                StaticManager.enterWordle = true;
                Debug.Log("runawaynow");
                continue;
            }
            if (tag.Trim() == "goToBucketCatchRoom")
            {
                StaticManager.enterWordle = true;
                Debug.Log("runawaynow");
                continue;
            }

            


            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag Could Not Be parsed: " + tag);
                continue;
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

            //chat gpt told me to add this guys
            ContinueStory();

        }
    }

    private void CheckForVariableUpdate() {
      foreach(string tag in currentStory.currentTags)
        {
            if(tag.StartsWith("UPDATE_VAR:"))
            {
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