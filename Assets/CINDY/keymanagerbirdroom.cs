using UnityEngine;

public class keymanagerbirdroom : MonoBehaviour
{
    public GameObject FlowerKey;
    void Start()
    {
        if (StaticManager.birdwon)
        {
            FlowerKey.SetActive(true);
        }
    }


}
