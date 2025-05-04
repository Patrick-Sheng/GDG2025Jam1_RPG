using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject player;

    private BossLaser bossLaser;
    private BossProjectile bossProjectile;
    private BossSpecial bossSpecial;

    void Start()
    {
        bossLaser = GetComponent<BossLaser>();
        bossProjectile = GetComponent<BossProjectile>();
        bossSpecial = GetComponent<BossSpecial>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // Replace with your actual trigger condition
        {
            bossLaser.FireLasers();
        }
        if (Input.GetKeyDown(KeyCode.A)) // Replace with your actual trigger condition
        {
            bossProjectile.ChargeAndFire();
        }
        if (Input.GetKeyDown(KeyCode.S)) // Replace with your actual trigger condition
        {
            bossSpecial.ActivateFloorIsLava();
        }
    }
}
