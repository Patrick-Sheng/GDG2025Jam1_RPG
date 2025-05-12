using TMPro;
using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    
    public TextMeshProUGUI instructionText;

    [Header("Door Sprites")]
    public Sprite doorLocked;
    public Sprite doorUnlocked;

    public GameObject door;
    private int progressIndex;

    private GameObject Key;
    private GameObject Gate;

    void Start()
    {
      Key = GameObject.FindGameObjectWithTag("Key");
      Gate = GameObject.FindGameObjectWithTag("Gate");

      Key.SetActive(false);

      door.GetComponent<SpriteRenderer>().sprite = doorLocked;

      progressIndex = 0;
      updateInstruction();
    }

    // Update is called once per frame
    void Update() 
    {
      switch(progressIndex) {
        case 1:
          if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
            updateInstruction();
          }
          break;
        case 2:
          if(Input.GetKeyDown(KeyCode.C)) {
            updateInstruction();
          }
          break;
        case 3:
          if(StaticManager.talkedToOldMan) {
            updateInstruction();
          }
          break;
        case 4:
          if(StaticManager.canOpenGate) {
            door.GetComponent<SpriteRenderer>().sprite = doorUnlocked;
            updateInstruction();
          }
          break;
        case 5:
          if(StaticManager.PlayerDead) {
            GameObject.FindGameObjectWithTag("instructionPanel").SetActive(false);
          }
          break;
        default:
          break;
      }
      
      if(StaticManager.talkedToOldMan) {
        Key.SetActive(true);
        StaticManager.talkedToOldMan = false;
      }
      if(StaticManager.canOpenGate) {
        Key.SetActive(false);
        Gate.SetActive(false);

        StaticManager.canOpenGate = false;
      } 
    }

    private void updateInstruction() {
      progressIndex++;

      switch(progressIndex) {
        case 1:
          instructionText.text = "Press arrow keys to move";
          break;
        case 2:
          instructionText.text = "Press c to interact";
          break;
        case 3:
          instructionText.text = "Talk to the old man";
          break;
        case 4:
          instructionText.text = "Walk around the park to find the key";
          break;
        default:
          instructionText.text = "Walk across the road";
          break;
      }

    }
}
