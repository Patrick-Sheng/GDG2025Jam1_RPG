using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float transparency = 0.1f;
    [SerializeField] private float cooldown = 1f;

    [Header("Config")]
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private GameObject attackPoint;

    private Animator anim; // Now serialized for Inspector assignment

    private bool isInCooldown = false;
    private bool isDashing = false;
    private float currentSpeed;

    private SpriteRenderer spriteRenderer;
    private PlayerDetection detection;
    
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 latestInput;
    public bool moving { get; private set; }
    private bool playerdeadonthefloor;
    private PlayerAttack attackSystem;
    private bool isInCombatRoom;
    public static bool dodio;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Auto-get Animator if not assigned in Inspector
        if (anim == null)
        {
            anim = GetComponent<Animator>();
            if (anim == null)
            {
                Debug.LogError("Animator component missing from player GameObject!");
            }
        }
        currentSpeed = moveSpeed;
        detection = GetComponentInChildren<PlayerDetection>();

        attackSystem = GetComponentInChildren<PlayerAttack>();
        attackSystem.enabled = false;
    }

    private void Update()
    {
        if (StaticManager.PlayerDead == true && playerdeadonthefloor == false)
        {
            anim.Play("dead");
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 2f, gameObject.transform.position.y - 0.8f);
            playerdeadonthefloor = true;
        }

        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Animate();
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            if (anim != null) anim.SetBool("Moving", false);
        }
        if (input != null) { latestInput = input; }
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        rb.linearVelocity = input.normalized * currentSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CombatRoom"))
        {
            isInCombatRoom = true;
            attackSystem.enabled = true;
        }

    }
    public void Move(InputAction.CallbackContext context)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            input = context.ReadValue<Vector2>();
        }
        else
        {
            input = Vector2.zero;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (!isInCooldown && !DialogueManager.GetInstance().dialogueIsPlaying&&isInCombatRoom)
        {
            isDashing = true;
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        isInCooldown = true;
        currentSpeed = dashSpeed;
        ModifySpriteRenderer(transparency);

        yield return new WaitForSeconds(dashTime);

        currentSpeed = moveSpeed;
        ModifySpriteRenderer(1f);
        isDashing = false;

        yield return new WaitForSeconds(cooldown);
        isInCooldown = false;
    }

    private void ModifySpriteRenderer(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }

    private void FaceEnemy()
    {
        if (detection.EnemyTarget != null)
        {
            Vector3 dirToEnemy = detection.EnemyTarget.transform.position -
                                 attackPoint.transform.position;
            anim.SetFloat("X", dirToEnemy.x);
            anim.SetFloat("Y", dirToEnemy.y);
        }
    }
    private void Animate()
    {
        if (StaticManager.PlayerDead == false) {
            if (anim == null) return;

            moving = input.magnitude > 0.1f || input.magnitude < -0.1f;
            anim.SetBool("Moving", moving);

            if (moving && detection.EnemyTarget == null) // If no enemies, face in player input
            {
                // horizontal has priority
                if (input.x != 0f)
                {
                    anim.SetFloat("X", input.x);
                    anim.SetFloat("Y", 0f);
                }
                else
                {
                    anim.SetFloat("X", 0f);
                    anim.SetFloat("Y", input.y);
                }
            }
            else
            {
                FaceEnemy();
            }
            anim.SetBool("Moving", moving);
        }
            
    }
    public Vector2 GetInput()
    {
        return latestInput;
    }
}