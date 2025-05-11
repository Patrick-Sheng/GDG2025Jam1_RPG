using UnityEngine;

public class gardendoorlogic : MonoBehaviour
{
    public GameObject TransistionTOgraveyard;
    public GameObject Doorlocked;
    public GameObject DoorVisualBlock;
    public GameObject GateWithoutKeys;
    public GameObject GateWithFlowerKey;
    public GameObject GateWithBone;
    void Start()
    {
        if (StaticManager.birdwon)
        {
            TransistionTOgraveyard.SetActive(true);
            Doorlocked.SetActive(false);
            DoorVisualBlock.SetActive(false);
            GateWithoutKeys.SetActive(false);
            GateWithFlowerKey.SetActive(true);
        }

        if (StaticManager.hasbone) {
            GateWithoutKeys.SetActive(false);
            GateWithBone.SetActive(true);
        }
    }

}
