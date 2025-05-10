using UnityEngine;

public class stickamn2 : MonoBehaviour
{
    public TextAsset GuyDiologue1;
    void Start()
    {
        if (StaticManager.fadeaway2 != true)
        {
            DialogueManager.GetInstance().EnterDialogueMode(GuyDiologue1);

        }
    }
}

