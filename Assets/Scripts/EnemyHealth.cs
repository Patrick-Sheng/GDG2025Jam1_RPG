using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [Header("Config")]
    [SerializeField] private int Health = 50;

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
        ShowDamageColor();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ShowDamageColor()
    {
        // Only stop the coroutine if it's actually running
        if (colorCoroutine != null)
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