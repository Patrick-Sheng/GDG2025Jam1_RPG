using System.Collections;
using UnityEngine;
using UnityEngine.Windows;

public class MeleeAttack : MonoBehaviour
{
    [Header("Config")]   
    [SerializeField] private int damage;
    [SerializeField] private float flipDuration;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Flip());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
        }
    }
    private IEnumerator Flip()
    {
        while (spriteRenderer != null)
        {
            spriteRenderer.flipY = !spriteRenderer.flipY;
            yield return new WaitForSeconds(flipDuration);
        }

    }
}
