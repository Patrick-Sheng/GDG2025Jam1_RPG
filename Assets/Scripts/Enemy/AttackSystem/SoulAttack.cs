using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SoulAttack : MonoBehaviour
{
    [SerializeField] private int Cooldown;
    [SerializeField] private int Damage;

    private float lastAttackTime;

    private Collider2D soulHitbox;
    
    void Start()
    {
        soulHitbox = GetComponent<Collider2D>();
        lastAttackTime = Time.time;
    }

    void Update()
    {
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
}
