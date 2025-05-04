using UnityEngine;

public class DisableGuardifGone : MonoBehaviour
{
    public GameObject Guard;
    public GameObject GuardSprite;

    void Start()
    {
        if (StaticManager.DisableGuardOnRoomEntry)
        {
            Guard.SetActive(false);
            GuardSprite.SetActive(false);
        }

    }



}
