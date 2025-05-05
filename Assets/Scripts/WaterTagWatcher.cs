using UnityEngine;
using Ink.Runtime;

public class WaterTagWatcher : MonoBehaviour
{
    public TextAsset inkJSON;

    private Story story;
    private bool hasGivenWater = false;

    void Start()
    {
        if (inkJSON != null)
        {
            story = new Story(inkJSON.text);
        }
        else
        {
            Debug.LogError("inkJSON is not assigned in WaterTagWatcher!");
        }
    }

    void Update()
    {
        if (story == null || DialogueManager.GetInstance() == null)
            return;

        // ��簡 ������ �±� Ȯ��
        if (DialogueManager.GetInstance().dialogueIsPlaying && !hasGivenWater)
        {
            if (story.canContinue)
            {
                string line = story.Continue();  // ���� �ٷ� ���� (�ʼ�!!)
                Debug.Log($"[Ink Line]: {line}");
            }

            foreach (string tag in story.currentTags)
            {
                if (tag.Trim().ToLower() == "give_water")
                {
                    WaterPour player = FindObjectOfType<WaterPour>();
                    if (player != null && !player.hasWater)
                    {
                        player.FillWater();
                        Debug.Log("Water granted by WaterTagWatcher!");
                        hasGivenWater = true;
                    }
                }
            }
        }
    }
}

