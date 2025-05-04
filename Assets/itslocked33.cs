using UnityEngine;

public class itslocked33 : MonoBehaviour
{
    public TextAsset itsLocked;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2
                (GameObject.FindGameObjectWithTag("Player").transform.position.x - 0.3f,
                GameObject.FindGameObjectWithTag("Player").transform.position.y );
            DialogueManager.GetInstance().EnterDialogueMode(itsLocked);

        }

    }
}
