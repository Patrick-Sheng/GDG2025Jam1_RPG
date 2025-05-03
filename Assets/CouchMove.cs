using UnityEngine;

public class CouchMove : MonoBehaviour
{

    public GameObject couch;

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player"){
      if (gameObject.name == "Left" && StaticManager.couchPosition < 2) {
        couch.transform.position = new Vector2(couch.transform.position.x + 1, couch.transform.position.y);
        StaticManager.couchPosition++;
      } else if (gameObject.name == "Right" && StaticManager.couchPosition > -2) {
        couch.transform.position = new Vector2(couch.transform.position.x - 1, couch.transform.position.y);
        StaticManager.couchPosition--;
      }
    }
  }

}
