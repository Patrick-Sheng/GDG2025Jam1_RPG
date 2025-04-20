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

    private Animator anim; // Now serialized for Inspector assignment

    private bool isInCooldown = false;
    private bool isDashing = false;
    private float currentSpeed;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 input;
    private bool moving;

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
    }

    private void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Animate();
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (anim != null) anim.SetBool("Moving", false);
        }
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        rb.velocity = input.normalized * currentSpeed;
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
        if (!isInCooldown && !DialogueManager.GetInstance().dialogueIsPlaying)
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

    private void Animate()
    {
        if (anim == null) return;

        moving = input.magnitude > 0.1f;
        anim.SetBool("Moving", moving);

        if (moving)
        {
            anim.SetFloat("X", input.x);
            anim.SetFloat("Y", input.y);
        }
    }
}