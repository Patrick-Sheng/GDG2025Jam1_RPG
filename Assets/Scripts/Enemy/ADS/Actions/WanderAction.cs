using UnityEngine;
using Random = UnityEngine.Random;

public class WanderAction : AbstractEnemyAction
{

    [Header("Config")]
    [SerializeField] private bool useDebug;
    [SerializeField] private bool useRandomMovement;

    [SerializeField] private float wanderSpeed;
    [SerializeField] private Vector2 moveRange;
    [SerializeField] private float minDistanceCheck = 0.5f;

    [Header("Obstacle Detection")]
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float detectionRange;

    private Vector3 movePosition;
    private Vector3 moveDirection;
    private float lastMoveTime;
    private float moveCooldown = 1;

    private void Start()
    {
        GetNewMoveDirection();
        lastMoveTime = Time.time;
    }

    public override void Act()
    {   
        if(Time.time > lastMoveTime + moveCooldown) 
        { 
        moveDirection = (movePosition - transform.position).normalized;
        transform.Translate(moveDirection*(wanderSpeed*Time.deltaTime));
        
        }
        if (CanGetNewPosition())
        {
            lastMoveTime = Time.time;
            GetNewMoveDirection();
        }
    }

    private void GetNewMoveDirection()
    {
        if (useRandomMovement)
        {
            movePosition = transform.position + GetRandomDirection();
        }
    }

    private bool CanGetNewPosition()
    {
        if (Vector3.Distance(transform.position, movePosition) < minDistanceCheck)
        {
            return true;
        }
        Collider2D collider = Physics2D.OverlapCircle(transform.position,
            detectionRange, obstacleLayer);
        if (collider != null)
        {
            Vector3 oppositeDirection = -moveDirection;
            transform.position += oppositeDirection * 0.1f;
            return true;
        }
        return false;
    }

    private Vector3 GetRandomDirection()
    {
        float randomX = Random.Range(-moveRange.x, moveRange.x);
        float randomY = Random.Range(-moveRange.y, moveRange.y);
        return new Vector3(randomX, randomY);
    }

    private void OnDrawGizmos()
    {
        if (useDebug == false) return;
        if (useRandomMovement) 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, moveRange * 2f);
        }

        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, movePosition);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

    }
}
