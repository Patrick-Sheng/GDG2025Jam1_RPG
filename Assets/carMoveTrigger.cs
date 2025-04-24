using UnityEngine;

public class carMoveTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StaticManager.carHit = true;

            StaticManager.carmove = true;
        }
    }
}