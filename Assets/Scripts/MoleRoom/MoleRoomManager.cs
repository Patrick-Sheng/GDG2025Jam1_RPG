using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class MoleRoomManager : MonoBehaviour
{
  


  void Update() {
    if (StaticManager.pushTimes >= 3) {
      StaticManager.wallCracked = true;
      Debug.Log("Changed var");
    }
  }
}
