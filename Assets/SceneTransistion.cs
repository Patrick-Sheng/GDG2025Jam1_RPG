using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneTransistion : MonoBehaviour
{


    public string SceneName;

    private void Awake()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            StaticManager.nextScene = SceneName;

            GameObject FadeObj = GameObject.FindGameObjectWithTag("Fade");
            Animator animator = FadeObj.GetComponent<Animator>();

            

            animator.Play("FadeIn");
        }
        


    }



}
