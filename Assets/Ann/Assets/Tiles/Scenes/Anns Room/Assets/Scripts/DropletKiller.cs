using UnityEngine;

public class DropletKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
      if (collision.gameObject.tag == "Droplet")
      {
        Destroy(collision.gameObject); // Destroy the droplet on collision
      }
    }
}
