using UnityEngine;

public class gardendoorlogic : MonoBehaviour
{
    public GameObject TransistionTOgraveyard;
    public GameObject Doorlocked;
    void Start()
    {
        if (StaticManager.birdwon)
        {
            TransistionTOgraveyard.SetActive(true);
            Doorlocked.SetActive(false);
        }
    }

}
