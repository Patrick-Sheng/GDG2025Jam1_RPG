using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private GameObject heartPrefab; // Should contain an Image component with full heart sprite

    private Image[] hearts;

    private void Awake()
    {
        InitializeHearts();

    }
    private void Update()
    {
        
    }

    void InitializeHearts()
    {
        // Clear existing hearts
        foreach (Transform child in transform) Destroy(child.gameObject);

        // Create hearts based on max HP (assuming 1 HP per heart)
        hearts = new Image[(int)playerConfig.MaxHealth];
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = Instantiate(heartPrefab, transform).GetComponent<Image>();
        }
    }
    
    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Show heart if index is less than current health, hide otherwise
            hearts[i].enabled = (i < playerConfig.CurrentHealth);
        }
    }

    //private void OnDestroy()
    //{
    //    // Clean up event subscription
    //    if (playerHealth != null)
    //    {
    //        playerHealth.OnHealthChanged.RemoveListener(UpdateHearts);
    //    }
    //}
}