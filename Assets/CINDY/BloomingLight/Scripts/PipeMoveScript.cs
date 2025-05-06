using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    //public float deadZone = -45;
    public float timeTilDeath = 5;
    private float timer = 0; 

    void Start()
    {
        
    }
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= timeTilDeath) {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
