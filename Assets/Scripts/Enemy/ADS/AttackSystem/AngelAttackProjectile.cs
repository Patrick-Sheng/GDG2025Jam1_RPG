using UnityEditor.Build;
using UnityEngine;

public class AngelAttackProjectile : MonoBehaviour
{
    public float speed { get; set; }
    public Vector2 Direction { get; set; }
    public int Damage { get; set; }
    public LayerMask ObstacleLayer {  get; set; }

    private void Update()
    {
        transform.Translate(Direction * (speed * Time.deltaTime));
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.1f, ObstacleLayer);
        if (hit != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null) { player.TakeDamage(Damage); }
            Destroy(gameObject);
        }
      
    }
}
