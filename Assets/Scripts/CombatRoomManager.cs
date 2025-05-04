using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatroomManager : MonoBehaviour
{
    public static CombatroomManager Instance;

    [Header("References")]
    public Transform playerPrefab;
    public Transform playerSpawnPoint;
    public BossController bossController;
    public Transform bossSpawnPoint;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void OnPlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}