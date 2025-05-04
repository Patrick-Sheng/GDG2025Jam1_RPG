using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform attackFixedPoint;
    

    [Header("Melee Attack")]
    [SerializeField] private GameObject melee;
    [SerializeField] private float meleeCooldown = 0.5f;
    private float lastMeleeTime;

    [Header("Laser Attack")]
    [SerializeField] private LaserAttack laser;
    [SerializeField] private float laserCooldown = 0.01f;
    [SerializeField] private int laserDamage;
    private float lastLaserTime;

    private PlayerInput playerInput;
    private InputAction meleeAction;
    private InputAction laserAction;
    private PlayerDetection detection;
    private PlayerController playerController;

    [Header("Laser Config")]
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private float laserWidth = 1f;
    [SerializeField] private float maxLaserLength = 100f; // Distance where laser becomes invisible
    [SerializeField] private LayerMask ObstacleLayer;

    private void Awake()
    {
        detection = GetComponentInChildren<PlayerDetection>();
        playerInput = GetComponent<PlayerInput>();
        meleeAction = playerInput.actions["Melee"];
        laserAction = playerInput.actions["Ranged"];
        

    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
    }

    private void Update()
    {
        if (meleeAction.triggered && Time.time >= lastMeleeTime + meleeCooldown&&playerController.moving)
        {
            StartCoroutine(MeleeAttack());
        }

        if (laserAction.triggered && Time.time >= lastLaserTime + laserCooldown && playerController.moving)
        {
            lastLaserTime = Time.time;
            LaserAttack();
        }
    }

    private GameObject meleeObject;
    private IEnumerator MeleeAttack()
    {
      
        lastMeleeTime = Time.time;
        meleeObject = Instantiate(melee, attackPoint.position, Quaternion.identity, attackFixedPoint);
        if (detection.EnemyTarget != null)
        {
            Vector3 dirToEnemy = detection.EnemyTarget.transform.position - attackPoint.position;
            float angle = Mathf.Atan2(-dirToEnemy.y, -dirToEnemy.x) * Mathf.Rad2Deg;
            meleeObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else // Default to player's facing direction
        {
            Vector2 playerInput = playerController.GetInput();
            float angle = Mathf.Atan2(-playerInput.y, -playerInput.x) * Mathf.Rad2Deg;
            meleeObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(meleeObject);
        
    }
    [Header("Laser Fade")]
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private Gradient laserColorGradient;
    private Material laserMaterial;


    private IEnumerator FadeLaser()
    {
        
        float elapsed = 0f;
        Color startColor = laserMaterial.GetColor("_Color");

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            laserMaterial.SetColor("_Color", laserColorGradient.Evaluate(t));
            laserLine.widthMultiplier = Mathf.Lerp(2f, 0f, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        laserLine.enabled = false;
        laserMaterial.SetColor("_Color", startColor); // Reset color
    }
    private void ShootLaserHitbox(Vector2 direction)
    {
        lastMeleeTime = Time.time;
        LaserAttack laserObject = Instantiate(laser);
        laserObject.transform.position = attackPoint.position;
        laserObject.Direction = direction;
        laserObject.Damage = laserDamage;
        laserObject.ObstacleLayer = ObstacleLayer;
        
    }


    private void DrawLaser()
    {   

        Vector2 direction = playerController.GetInput().normalized; 
        if (detection.EnemyTarget != null)
        {
            direction = detection.EnemyTarget.transform.position - attackPoint.position;

        }
        ShootLaserHitbox(direction);
        RaycastHit2D hit = Physics2D.Raycast(
            attackPoint.position,
            direction,
            maxLaserLength,
            ObstacleLayer
        );

        float laserLength = hit.collider ? hit.distance : maxLaserLength;

        laserMaterial = Instantiate(laserLine.material);
        laserLine.material = laserMaterial;
        laserLine.textureMode = LineTextureMode.Tile;
        laserLine.colorGradient = new Gradient()
        {
            alphaKeys = new GradientAlphaKey[]
            {
            new GradientAlphaKey(1, 0),
            new GradientAlphaKey(0, 1)
            }
        };
        laserLine.SetPosition(0, attackPoint.position);
        laserLine.SetPosition(1, (Vector2)attackPoint.position + direction * laserLength);

        laserMaterial.SetColor("_Color", laserColorGradient.Evaluate(0));
        
        laserLine.enabled = true;

        StartCoroutine(FadeLaser());
        StartCoroutine(HideLaserAfterDelay(0.5f));
        
    }
    private void LaserAttack()
    {
        DrawLaser();
    }

    private IEnumerator HideLaserAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        laserLine.enabled = false;
    }
}
