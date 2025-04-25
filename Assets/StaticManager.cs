using UnityEditor.Build;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    public static bool PlayerDead;
    public static bool carHit;

    // public static bool indio;
    public static bool carmove; 

    public static bool canOpenGate;

    public static bool talkedToOldMan;

    public static bool resettrigger;
    public static string nextScene;

    public static void UpdateVariable(string varName, string value) {
        switch(varName)
        {
            case "talkedToOldMan":
                if(bool.TryParse(value, out bool result))
                    talkedToOldMan = result;
                break;
        }
        
        print($"Updated {varName} to {value}");
    }
}
