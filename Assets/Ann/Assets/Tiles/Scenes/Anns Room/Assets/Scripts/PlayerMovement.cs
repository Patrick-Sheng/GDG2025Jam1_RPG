using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
    
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(1, 0) * 17f;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector2(-1, 0) * 17f; 
        } else {
            rb.linearVelocity = new Vector2(0, 0);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
      if (collision.gameObject.tag == "Droplet")
      {
        Destroy(collision.gameObject); // Destroy the droplet on collision
        FindObjectOfType<WaterGameManager>().IncreaseScore(); // Increase the score when a droplet is collected
      }
    }
}
