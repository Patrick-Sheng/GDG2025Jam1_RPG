using TMPro;
using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    
    public TextMeshProUGUI instructionText;
    private int progressIndex;

    void Start()
    {
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
            print(StaticManager.talkedToOldMan);
            updateInstruction();
          }
          break;
        default:
          break;
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
        default:
          instructionText.text = "Walk across the road";
          break;
      }

    }
}
