using UnityEngine;

public class HeavenMainPlayerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject HeavenFromGate;
    public GameObject cam;
    void Start()
    {
        if (StaticManager.gatetoheaven)
        {
            StaticManager.gatetoheaven = false;
            cam.transform.position = new Vector3(31.8280f, 3.305864f, -1.85f);
            Player.transform.position = HeavenFromGate.transform.position;
        }
    }

}
