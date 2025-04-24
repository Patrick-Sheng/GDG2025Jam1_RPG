using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("Config")]   
    [SerializeField] private int damage;
    public EnemyHealth EnemyTarget { get; set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
        }
    }
}
