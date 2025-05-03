using UnityEngine;

public class buttonPressed : MonoBehaviour
{
  private bool alreadyStepped;
  public Animator anim;
  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player") {
      anim.Play("brownPressed");

      // There is some bug over here, to be fixed
      // Buttons will not clear "alreadyStepped" after confirmation

      if (gameObject.tag == "CorrectButton"){
        if (alreadyStepped == false){
          StaticManager.numberOfCorrect++;
          alreadyStepped = true;

        }

      } else if (gameObject.tag == "ConfirmButton") {
        if (StaticManager.numberOfCorrect == 3) {
          print("You passed!");
          print(StaticManager.numberOfCorrect);
        } else {
          print("You failed");
          print(StaticManager.numberOfCorrect);
        }
        ResetAllButtons();

        StaticManager.numberOfCorrect = 0;
      } else {
        StaticManager.numberOfCorrect = 999;
      }
    }
  }

  // void OnTriggerExit2D(Collider2D collision)
  // {
  //   if (collision.gameObject.tag == "Player") {
  //     anim.Play("brownReleased");
  //   }
  // }

  private void ResetAllButtons()
    {
      // Find all buttonPressed components in the scene
      buttonPressed[] allButtons = FindObjectsOfType<buttonPressed>();
      
      foreach (buttonPressed button in allButtons)
      { 
        button.anim.Play("brownReleased");
        button.alreadyStepped = false;
      }
    }
}
