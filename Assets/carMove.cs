using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class carMove : MonoBehaviour
{
    public GameObject dead;
    private float timer = 0.2f;
    private bool timerstart;

    private float Speed = 80f;
    private bool hitPlayer;

    public GameObject black;
    public GameObject Player;

    private float timer2 = 1.3f;
    private bool timer2start;

    public AudioSource carhit;
    public Animator anim;
    private bool timer3start;
    private float timer3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            carhit.Play();
            timerstart = true;
            hitPlayer = true;
        }
    }
    void Update()
    {
        if (timerstart)
        {
            timer = timer - Time.deltaTime;
            if (timer < 0)
            {
                black.SetActive(true);
                anim.Play("carAnim");

                timer2start = true;
                timerstart = false;

            }

        }

        if (timer2start)
        {
            timer2 = timer2 - Time.deltaTime;
            if (timer2 < 0)
            {
                black.SetActive(false);
                timer2start = false;
                StaticManager.PlayerDead = true;

                var sr = Player.GetComponent<SpriteRenderer>();
                sr.enabled = false;

                timer3start = true;

            }
        }

        if (timer3start)
        {
            timer3 = timer3 + Time.deltaTime;
            if (timer3 > 4)
            {
                StaticManager.PlayerDead = false;
                SceneManager.LoadScene("TITLE");
            }
        }

        if (StaticManager.carmove == true && hitPlayer == true)
        {
            
            if (!StaticManager.PlayerDead)
            {
                dead.SetActive(true);
                var sr = Player.GetComponent<SpriteRenderer>();
                sr.enabled = false;
                //gameObject.transform.localScale = new Vector3(1, 1, 1);
                gameObject.transform.position = new Vector2(Player.transform.position.x, gameObject.transform.position.y);

            }
        }

        if (StaticManager.carmove == true && hitPlayer == false)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + Speed * Time.deltaTime, gameObject.transform.position.y);
        }
    }
}
