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
            if (gameObject.name == "toCindy")
            {
                if (GameObject.FindGameObjectWithTag("WordleKey") != null)
                {
                    Destroy(GameObject.FindGameObjectWithTag("WordleKey"));
                }
            }

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

            if (gameObject.tag == "goingFromMoleRoom1")
            {
                StaticManager.goingFromMoleRoom1 = true;
            }
            if (gameObject.tag == "goingFromMoleRoom2")
            {
                StaticManager.goingFromMoleRoom2 = true;
            }
            if (gameObject.tag == "goingFromMoleRoom3")
            {
                StaticManager.goingFromMoleRoom3 = true;
            }
            if (gameObject.tag == "goingFromMoleRoom4")
            {
                StaticManager.goingFromMoleRoom4 = true;
            }
            if (gameObject.tag == "goingFromGardenRoom")
            {
                StaticManager.goingFromGardenRoom = true;
            }

            StaticManager.nextScene = SceneName;

            GameObject FadeObj = GameObject.FindGameObjectWithTag("Fade");
            Animator animator = FadeObj.GetComponent<Animator>();
            animator.Play("FadeIn");
        }
        


    }



}
