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
            if (gameObject.name == "yellowToHallway")
            {
                StaticManager.YellowToHall = true;
            }
            if (gameObject.name == "doghall")
            {
                StaticManager.fromgirlroom = true;

            }
            if (gameObject.name == "doghallfromdog")
            {
                StaticManager.fromdoghall = true;

            }



            if (gameObject.tag == "gotohevenmain")
            {
                StaticManager.gatetoheaven = true;
            }

            if (gameObject.tag == "goingtobirdroom")
            {
                StaticManager.goingfrombirdroom = true;
            }

            if (gameObject.tag == "gofromgraveyard")
            {
                StaticManager.gofromgraveyard = true;
            }

            StaticManager.nextScene = SceneName;

            GameObject FadeObj = GameObject.FindGameObjectWithTag("Fade");
            Animator animator = FadeObj.GetComponent<Animator>();

            

            animator.Play("FadeIn");
        }
        


    }



}
