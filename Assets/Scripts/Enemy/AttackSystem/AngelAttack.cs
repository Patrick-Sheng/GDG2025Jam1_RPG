using Unity.VisualScripting;
using UnityEngine;

public class AngelAttack : MonoBehaviour
{
    [Header("Angel Attack")]
    [SerializeField] private AngelAttackProjectile Projectile;
    [SerializeField] private float Cooldown = 1f;
    [SerializeField] private int Damage;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float Speed;
    [SerializeField] private LayerMask ObstacleLayer;

    private EnemyController Angel;
    private float lastAttackTime;
    private Vector2 direction;
    void Start()
    {
        Angel = GetComponent<EnemyController>();
    }

    void Update()
    {
        if (Angel.Player != null)
        {
            direction = Angel.Player.transform.position - attackPoint.position;
            if (Time.time > lastAttackTime + Cooldown)
            {
                ShootProjectile(direction);
            }
        }
    }
    private void ShootProjectile(Vector2 direction)
    {
        lastAttackTime = Time.time;
        AngelAttackProjectile projectileObject = Instantiate(Projectile);
        projectileObject.transform.position = attackPoint.position;
        projectileObject.Direction = direction.normalized;
        projectileObject.Damage = Damage;
        projectileObject.speed = Speed;
        projectileObject.ObstacleLayer = ObstacleLayer;

    }
}
