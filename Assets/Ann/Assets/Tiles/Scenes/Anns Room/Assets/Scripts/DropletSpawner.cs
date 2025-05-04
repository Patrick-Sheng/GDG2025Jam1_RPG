using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    
    public GameObject dropletPrefab; // Prefab of the droplet to spawn
    public float spawnRate = 2f; // Time interval between spawns

    public float minX = -10f; // Minimum height for the droplet to spawn
    public float maxX = 10f; // Maximum height for the droplet to spawn


  private void OnEnable()
  {
    InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
  }

  private void OnDisable()
  {
    CancelInvoke(nameof(Spawn));
  }

  private void Spawn() {
    GameObject droplet = Instantiate(dropletPrefab, transform.position, Quaternion.identity);
    float randomX = Random.Range(minX, maxX); // Generate a random height within the specified range
    droplet.transform.position = new Vector3(randomX, transform.position.y, transform.position.z); // Set the droplet's position
  }
}
