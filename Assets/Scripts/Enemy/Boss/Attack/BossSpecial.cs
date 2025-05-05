using System.Collections;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class BossSpecial : MonoBehaviour, BossAttackInterface
{
    [Header("Lava Settings")]
    [SerializeField] private float lavaDuration = 7f;
    [SerializeField] private float damageCooldown;
    [SerializeField] private int lavaDamage = 1;
    [SerializeField] private float lavaSpreadSpeed;
    [SerializeField] private float lavaSpreadRate;
    [SerializeField] private float maxLavaRadius;
    [SerializeField] private Material lavaMaterial;
    [SerializeField] private GameObject safeAreaPrefab;
    [SerializeField] private string sortingLayerName = "Foreground";

    [Header("Safe Area Settings")]
    [SerializeField] private float safeAreaRadius = 2f;
    [SerializeField] private float minDistanceFromPlayer = 5f;

    private Transform player;
    private GameObject lavaEffect;
    private GameObject safeArea;
    private float currentLavaRadius;
    private float damageTimer;
    public bool isAttacking {  get; set; }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            StartCoroutine(FloorIsLavaRoutine());
        }
    }

    private IEnumerator FloorIsLavaRoutine()
    {

        // Initialize lava effect
        isAttacking = true;
        currentLavaRadius = 10f;
        damageTimer = 0f;

        // Create lava visual
        lavaEffect = new GameObject("LavaEffect");
        lavaEffect.transform.position = transform.position;
        SpriteRenderer lavaRenderer = lavaEffect.AddComponent<SpriteRenderer>();
        //if (lavaRenderer != null)
        //{
            lavaRenderer.sortingLayerName = sortingLayerName;
        //}
        lavaRenderer.material = lavaMaterial;
        lavaRenderer.sprite = Sprite.Create(
            Texture2D.whiteTexture,
            new Rect(0, 0, 1, 1),
            new Vector2(0.5f, 0.5f)
        );
        lavaRenderer.color = new Color(1, 0, 0, 0.3f);
        lavaEffect.transform.localScale = Vector3.zero;

        // Create safe area
        SpawnSafeArea();
        float temp = lavaSpreadSpeed;
        // Lava spread phase
        while (currentLavaRadius < maxLavaRadius)
        {
            lavaSpreadSpeed *= lavaSpreadRate;
            currentLavaRadius = Mathf.Min(currentLavaRadius + lavaSpreadSpeed * Time.deltaTime, maxLavaRadius);
            lavaEffect.transform.localScale = Vector3.one * currentLavaRadius * 2;
            //Debug.Log((maxLavaRadius, currentLavaRadius));
            yield return null;
        }
        lavaSpreadSpeed = temp;
        // Damage phase
        float lavaTimer = 0f;
        while (lavaTimer < lavaDuration)
        {
            lavaTimer += Time.deltaTime;
            damageTimer += Time.deltaTime;

            // Damage player if not in safe area
            if (damageTimer >= damageCooldown && !IsPlayerInSafeArea())
            {
                player.GetComponent<PlayerHealth>().TakeDamage(lavaDamage);
                damageTimer = 0f;
            }

            yield return null;
        }

        // Clean up
        Destroy(lavaEffect);
        Destroy(safeArea);
        isAttacking = false;
    }

    private void SpawnSafeArea()
    {
        // Find valid position for safe area
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)player.position + randomDirection * minDistanceFromPlayer;

        // Adjust position if near walls
        RaycastHit2D hit = Physics2D.Raycast(player.position, randomDirection, minDistanceFromPlayer, LayerMask.GetMask("Obstacle"));
        if (hit.collider != null)
        {
            spawnPosition = hit.point - randomDirection * safeAreaRadius;
        }

        // Create safe area
        safeArea = Instantiate(safeAreaPrefab, spawnPosition, Quaternion.identity);
        safeArea.transform.localScale = Vector3.one * safeAreaRadius * 2;
    }

    private bool IsPlayerInSafeArea()
    {
        if (safeArea == null) return false;
        float distance = Vector2.Distance(player.position, safeArea.transform.position);
        return distance <= safeAreaRadius;
    }
}