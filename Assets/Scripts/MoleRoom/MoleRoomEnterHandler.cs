using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoleRoomEnterHandler : MonoBehaviour
{
    public GameObject Player;
    public GameObject previousRoom;
    public GameObject nextRoom;

    UnityEngine.SceneManagement.Scene scene;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    void Start()
    {
      Debug.Log("MoleRoomEnterHandler started for scene: " + scene.name);
      switch (scene.name) {
        case "MoleRoom1":
            if (StaticManager.goingFromMoleRoom2){
                StaticManager.goingFromMoleRoom2 = false;
                Player.transform.position = nextRoom.transform.position;
            }
            break;
        case "MoleRoom2":
            if (StaticManager.goingFromMoleRoom1){
                StaticManager.goingFromMoleRoom1 = false;
                Player.transform.position = previousRoom.transform.position;
            }
            if (StaticManager.goingFromMoleRoom3){
                StaticManager.goingFromMoleRoom3 = false;
                Player.transform.position = nextRoom.transform.position;
            }
            break;
        case "MoleRoom3":
            if (StaticManager.goingFromMoleRoom2){
                StaticManager.goingFromMoleRoom2 = false;
                Player.transform.position = previousRoom.transform.position;
            }
            if (StaticManager.goingFromMoleRoom4){
                StaticManager.goingFromMoleRoom4 = false;
                Player.transform.position = nextRoom.transform.position;
            }
            break;
        case "MoleRoom4":
          Debug.Log("MoleRoom4 entered");
            if (StaticManager.goingFromMoleRoom3){
                StaticManager.goingFromMoleRoom3 = false;
                Player.transform.position = previousRoom.transform.position;
            }
            if (StaticManager.goingFromGardenRoom){
                StaticManager.goingFromGardenRoom = false;
                Player.transform.position = nextRoom.transform.position;
            }
            break; 
        default:
            Debug.LogError("Scene not recognized: " + scene.name);
            break;
      }
    }
}
