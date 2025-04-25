using UnityEngine;
using UnityEngine.Windows;

public class MeleeAttack : MonoBehaviour
{
    [Header("Config")]   
    [SerializeField] private int damage;
    [SerializeField] private GameObject detection;
    public EnemyHealth EnemyTarget { get; set; }
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
        }
    }
    //private void Animate()
    //{

    //    if (detection.EnemyTarget == null) // If no enemies, face in player input
    //    {
    //        anim.SetFloat("X", input.x);
    //        anim.SetFloat("Y", input.y);
    //    }
    //    else
    //    {
    //        FaceEnemy();
    //    }
    //}
}
