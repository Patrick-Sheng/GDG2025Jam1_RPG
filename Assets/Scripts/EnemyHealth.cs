using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [Header("Config")]
    [SerializeField] private int Health = 100;

    private SpriteRenderer sprite;
    private int currentHealth;
    private Color initialColour;
    private Coroutine colorCoroutine;

    private void Awake()
    {
        
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        currentHealth = Health;
        initialColour = sprite.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ShowDamageColor()
    {
        if (colorCoroutine == null)
        {
            StopCoroutine(colorCoroutine);
        }

        colorCoroutine = StartCoroutine(IETakeDamage());
    }

    private IEnumerator IETakeDamage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = initialColour;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}