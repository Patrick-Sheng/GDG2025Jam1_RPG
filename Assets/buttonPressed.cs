using UnityEngine;

public class buttonPressed : MonoBehaviour
{
  private bool alreadyStepped;
  public Animator anim;
  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player") {
      anim.Play("brownPressed");

      if (gameObject.tag == "CorrectButton"){
        if (alreadyStepped == false){
          StaticManager.numberOfCorrect++;
          alreadyStepped = true;

        }

      } else if (gameObject.tag == "ConfirmButton") {
        if (StaticManager.numberOfCorrect == 3) {
          print("You passed!");
        } else {
          print("You failed");
          StaticManager.numberOfCorrect = 0;
        }
      } else {
        StaticManager.numberOfCorrect = 999;
      }
    }
  }

  void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player") {
      anim.Play("brownReleased");
    }
  }
}
