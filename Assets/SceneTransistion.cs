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

            if (gameObject.tag == "doghall")
            {
                StaticManager.fromdoghall = true;
                
            }
            if (gameObject.tag == "doghallfromdog")
            {
                StaticManager.fromdoghallfromdog = true;
                
            }
            if (gameObject.tag == "gotohevenmain")
            {
                StaticManager.gatetoheaven = true;
            }

            StaticManager.nextScene = SceneName;

            GameObject FadeObj = GameObject.FindGameObjectWithTag("Fade");
            Animator animator = FadeObj.GetComponent<Animator>();

            

            animator.Play("FadeIn");
        }
        


    }



}
