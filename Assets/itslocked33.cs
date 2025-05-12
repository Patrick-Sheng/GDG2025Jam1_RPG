using UnityEngine;

public class itslocked33 : MonoBehaviour
{
    public TextAsset itsLocked;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2
                (GameObject.FindGameObjectWithTag("Player").transform.position.x,
                GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.3f );
            DialogueManager.GetInstance().EnterDialogueMode(itsLocked);

        }

    }
}
