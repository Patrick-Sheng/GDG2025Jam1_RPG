using Ink.Parsed;
using UnityEngine;

public class gatediologue : MonoBehaviour
{
    public TextAsset guardGate;

    public void NoGaurd()
    {
        StaticManager.noguard = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {




        if (collision.gameObject.tag == "Player" && StaticManager.noguard == false)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2
                (GameObject.FindGameObjectWithTag("Player").transform.position.x,
                GameObject.FindGameObjectWithTag("Player").transform.position.y - 0.3f);
            DialogueManager.GetInstance().EnterDialogueMode(guardGate);

        }

    }
}
