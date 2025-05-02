using UnityEngine;

public class HeavenMainPlayerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject HeavenFromGate;
    void Start()
    {
        if (StaticManager.gatetoheaven)
        {
            StaticManager.gatetoheaven = false;
            Player.transform.position = HeavenFromGate.transform.position;
        }
    }

}
