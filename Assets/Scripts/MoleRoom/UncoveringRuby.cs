using UnityEngine;
using UnityEngine.UI;

public class UncoveringRuby : MonoBehaviour
{
    [Header("Target GameObject with Image Component")]
    public GameObject targetObject;

    [Header("List of Sprites to Cycle Through (6 total)")]
    public Sprite[] images = new Sprite[6];

    private int currentIndex = 0;

    public void UpdateImage()
    {
        if (images.Length == 0)
            return;

        if (currentIndex < images.Length)
        {
            targetObject.GetComponent<SpriteRenderer>().sprite = images[currentIndex];
            currentIndex++;
        }
        else
        {
            Debug.Log("All images have been shown.");
        }
    }
}
