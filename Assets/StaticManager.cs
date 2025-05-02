using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class StaticManager : MonoBehaviour
{
    public static bool PlayerDead;
    public static bool carHit;

<<<<<<< HEAD
    public static int numberOfCorrect;
=======
    // public static bool indio;
    public static bool carmove; 

    public static bool canOpenGate;

    public static bool talkedToOldMan;

>>>>>>> 1eb4687061b60c07074a15637837d6fb1ebf44ae
    public static bool resettrigger;
    public static string nextScene;

    public static void UpdateVariable(string varName, string value) {
      bool result;

      switch(varName)
      {
        case "talkedToOldMan":
          if(bool.TryParse(value, out result))
            talkedToOldMan = result;
          break;
        case "canOpenGate":
          if(bool.TryParse(value, out result))
            canOpenGate = result;
          break;
      }
      
      print($"Updated {varName} to {value}");
    }
}
