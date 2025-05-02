using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SoulAttack : MonoBehaviour
{
    [SerializeField] private int Cooldown;
    [SerializeField] private int Damage;
    [SerializeField] private float attackMoveSpeed;
    private float lastAttackTime;
    

    private Collider2D soulHitbox;
    private EnemyController thisSoul;
    
    void Start()
    {
        soulHitbox = GetComponent<Collider2D>();
        thisSoul = GetComponent<EnemyController>();
        lastAttackTime = Time.time;
    }

    void Update()
    {
        ChasePlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Time.time > lastAttackTime + Cooldown)
            {
                AttackPlayer(other);
            }
        }
    }

    private void AttackPlayer(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(Damage);
        }
    }

    private void ChasePlayer()
    {
        if (thisSoul.Player != null)
        {
            Vector2 direction = (thisSoul.Player.position - transform.position).normalized;

            float step = attackMoveSpeed * Time.deltaTime; 
            transform.position = Vector2.MoveTowards(transform.position,
                                    thisSoul.Player.position, step);
        }
    }
}
