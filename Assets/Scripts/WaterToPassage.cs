using UnityEngine;

public class WaterToPassage : MonoBehaviour
{
    public Animator animator;         
    public string triggerName = "Transform";  

    public void PlayTransformation()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
        else
        {
            Debug.LogWarning("Animator not assigned on " + gameObject.name);
        }
    }
}

