using UnityEngine;

public class DisableGuardifGone : MonoBehaviour
{
    public GameObject Guard;
    public GameObject GuardSprite;

    public GameObject pancake;
    void Start()
    {
        if (StaticManager.DisableGuardOnRoomEntry)
        {
            Guard.SetActive(false);
            GuardSprite.SetActive(false);
        }

    }
    private void Update()
    {
        if (StaticManager.stealpancakes)
        
            if (GameObject.FindGameObjectWithTag("pancake") != null)
            {
                GameObject.FindGameObjectWithTag("pancake").SetActive(false);

            }
    }
    }



