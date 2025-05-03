using UnityEngine;

public class DetectPlayerAction : AbstractEnemyAction
{
    [Header("Config")]
    [SerializeField] private float rangeDetection;
    [SerializeField] private LayerMask playerMask;

    private EnemyController enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyController>();
    }

    public override void Act()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position,
            rangeDetection, playerMask);
        if (collider == null)
        {
            enemy.Player = null;
            return;
        }

        enemy.Player = collider.transform;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangeDetection);
    }
}
