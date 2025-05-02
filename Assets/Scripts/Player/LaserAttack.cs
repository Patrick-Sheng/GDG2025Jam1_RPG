using UnityEngine;
using System.Collections;

public class LaserAttack : MonoBehaviour
{
    [Header("Laser Config")]
    [SerializeField] private float speed;
    public Vector2 Direction { get; set; }
    public int Damage { get; set; }

    private void Update()
    {
        transform.Translate(Direction * (speed * Time.deltaTime));
        StartCoroutine(SelfDestroy());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.TakeDamage(Damage);
        }
        
    }
    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
