using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float speed;
    private int damage;
    private float lifetime = 20f;
    private float currentLifetime;
    private bool isDamaged;
    public BossProjectile parent { private get; set; }
    

    public void Initialize(Vector2 dir, float spd, int dmg)
    {
        direction = dir;
        speed = spd;
        damage = dmg;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * speed;
        currentLifetime = lifetime;
    }

    void Update()
    {

        //float scale = Mathf.PingPong(Time.time * scaleSpeed, maxScale - 1f) + 1f;
        //transform.localScale = Vector3.one * scale;

        currentLifetime -= Time.deltaTime;
        if (currentLifetime <= 0)
        {
            Destroy(gameObject);
            parent.isAttacking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null&&!isDamaged)
            {
                player.TakeDamage(damage);
                isDamaged = true;          
            }
        }else if (other.CompareTag("Enemy")|| other.CompareTag("PlayerAttackPoint"))
        {
            return;
        }
        else if (!other.isTrigger) // Hit solid objects
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        //if (impactEffect != null)
        //{
        //    ParticleSystem effect = Instantiate(impactEffect, transform.position, Quaternion.identity);
        //    effect.Play();
        //    Destroy(effect.gameObject, effect.main.duration);
        //}
        Destroy(gameObject);
        parent.isAttacking = false;
    }
}