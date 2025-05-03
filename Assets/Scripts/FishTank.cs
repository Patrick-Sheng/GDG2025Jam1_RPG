using UnityEngine;
using System.Collections;

public class FishTank : MonoBehaviour
{
    public int waterLevel = 0;
    public int maxWater = 3;

    public TextAsset fullDialogueInkJSON;
    public TextAsset dialogue1;
    public TextAsset dialogue2;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            WaterPour player = FindObjectOfType<WaterPour>();

            if (player != null && player.hasWater && waterLevel < maxWater)
            {
                player.EmptyWater();
                waterLevel++;

                Debug.Log($"waterfull: {waterLevel}/{maxWater}");

                if (waterLevel == 1 && dialogue1 != null)
                {
                    StartCoroutine(ShowAndCloseDialogue(dialogue1));
                }
                else if (waterLevel == 2 && dialogue2 != null)
                {
                    StartCoroutine(ShowAndCloseDialogue(dialogue2));
                }
                else if (waterLevel == maxWater && fullDialogueInkJSON != null)
                {
                    Debug.Log("Fish Tank is now Full!");
                    StartCoroutine(ShowAndCloseDialogue(fullDialogueInkJSON));
                }
            }
        }
    }

    private IEnumerator ShowAndCloseDialogue(TextAsset dialogue)
    {
        DialogueManager.GetInstance().EnterDialogueMode(dialogue);

        // 2초 동안 대화 보여주고
        yield return new WaitForSeconds(2f);

        // 자동 종료
        DialogueManager.GetInstance().ExitDialogueMode();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}

