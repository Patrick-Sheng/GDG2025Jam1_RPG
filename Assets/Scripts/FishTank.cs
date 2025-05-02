using UnityEngine;

public class FishTank : MonoBehaviour
{
    public int waterLevel = 0;
    public int maxWater = 3;

    public TextAsset fullDialogueInkJSON; // 물 3번 채운 후 출력할 대사

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

                if (waterLevel == maxWater)
                {
                    Debug.Log("Fish Tank is now Full!");
                    DialogueManager.GetInstance().EnterDialogueMode(fullDialogueInkJSON);
                }
            }
        }
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
