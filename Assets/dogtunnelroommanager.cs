using UnityEngine;

public class dogtunnelroommanager : MonoBehaviour
{
    public TextAsset DogAfterBone;
    void Start()
    {
        DialogueManager.GetInstance().EnterDialogueMode(DogAfterBone);
    }

    void Update()
    {
        
    }
}
