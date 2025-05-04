using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private HeartDisplay heartDisplay;

    // Event that triggers when health changes
    public UnityEvent<float> OnHealthChanged = new UnityEvent<float>();


    private void Start()
    {
        // Initialize health
        playerConfig.CurrentHealth = playerConfig.MaxHealth;
    }
    private void Update()
    {
        // Health increase on Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(1);
        }
        // Health decrease on R
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(1);
        }
    }
    public void TakeDamage(int amount)
{
    if (playerConfig.CurrentHealth > 0f)
    {
        playerConfig.CurrentHealth = Mathf.Max(0, playerConfig.CurrentHealth - amount);
        heartDisplay.UpdateHearts(); 
        //OnHealthChanged?.Invoke(playerConfig.CurrentHealth);
    }
}

public void Heal(int amount)
{
    if (playerConfig.CurrentHealth < playerConfig.MaxHealth)
    {
        playerConfig.CurrentHealth = Mathf.Min(playerConfig.CurrentHealth + amount, playerConfig.MaxHealth);
        heartDisplay.UpdateHearts(); 
        //OnHealthChanged?.Invoke(playerConfig.CurrentHealth);
    }
}


    private void PlayerDead()
    {
        Destroy(gameObject);
    }
}