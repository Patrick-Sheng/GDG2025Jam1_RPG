using UnityEngine;

public class BirdScript : MonoBehaviour
{   
    public Rigidbody2D myRigidbody;
    public float flapStrength = 5;
    public LogicManagerScript logic;
    public bool birdIsAlive = true;
    public AudioClip flapSound;
    public AudioSource audioSource;
    public AudioClip crashSound;
    void Start()
    {
        // myRigidbody.freezeRotation = true; // freeze the bird on z axis
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;  // change the number to set how much you want the bird to fly up
            audioSource.PlayOneShot(flapSound);
            // Hide the tutorial text the first time player presses space
            if (logic.tutorialText.gameObject.activeSelf)
            {
                logic.tutorialText.gameObject.SetActive(false);
            }
        }

            // Get screen bounds in world space
        float screenTop = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        float screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        // Game over if bird goes off-screen
        if ((transform.position.y > screenTop || transform.position.y < screenBottom) && birdIsAlive)
        {
            logic.tutorialText.gameObject.SetActive(false);
            audioSource.PlayOneShot(crashSound);
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!birdIsAlive) return; // Ignore collisions after first crash

        Debug.Log("Trigger entered with: " + collision.gameObject.name);
        audioSource.PlayOneShot(crashSound);
        logic.gameOver();
        birdIsAlive = false;
    }
}
