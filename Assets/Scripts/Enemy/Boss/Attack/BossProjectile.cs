using UnityEngine;

public class BossProjectile : MonoBehaviour, BossAttackInterface
{
    [Header("Settings")]
    [SerializeField] private float chargeTime = 2f;
    [SerializeField] private float projectileSpeed = 1f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float maxRadius = 3f;
    [SerializeField] private EnergyOrb energyOrbPrefab;
    [SerializeField] private GameObject chargingEffectPrefab;

    private Transform player;
    private GameObject currentChargeEffect;
    private float currentChargeTime;
    public bool isAttacking { get; set; }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isAttacking = false;
    }

    public void Attack()
    {
        if (currentChargeEffect == null)
        {
            isAttacking = true;
            StartCoroutine(ChargeAndFireRoutine());
        }
    }

    private System.Collections.IEnumerator ChargeAndFireRoutine()
    {
        // Create charging effect
        currentChargeEffect = Instantiate(chargingEffectPrefab, transform.position, Quaternion.identity);
        currentChargeEffect.transform.SetParent(transform);

        // Charge up
        currentChargeTime = 0f;
        while (currentChargeTime < chargeTime)
        {
            currentChargeTime += Time.deltaTime;
            float currentRadius = Mathf.Lerp(0.1f, maxRadius, currentChargeTime / chargeTime);
            currentChargeEffect.transform.localScale = Vector3.one * currentRadius;
            yield return null;
        }

        // Fire projectile
        Vector2 direction = (player.position - transform.position).normalized;
        EnergyOrb orb = Instantiate(energyOrbPrefab, transform.position, Quaternion.identity);
        orb.parent = this;
        orb.Initialize(direction, projectileSpeed, damage);

        // Clean up
        Destroy(currentChargeEffect);
        currentChargeEffect = null;
    }
}