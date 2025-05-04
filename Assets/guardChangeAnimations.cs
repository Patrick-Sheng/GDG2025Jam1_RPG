using UnityEditor;
using UnityEngine;

public class guardChangeAnimations : MonoBehaviour
{
    public gatediologue gatediologue;
    public GameObject GuardNPC;
    private Animator anim;
    private bool done;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (StaticManager.runaway && done == false)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                StaticManager.DisableGuardOnRoomEntry = true;
                gatediologue.NoGaurd();
                anim.Play("RunawayNocoin");
                done = true;
                Destroy(GuardNPC);
            }

        }

        else if (StaticManager.justpancakerun && done == false)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                StaticManager.DisableGuardOnRoomEntry = true;
                gatediologue.NoGaurd();
                anim.Play("RunawayNocoin");
                done = true;
                Destroy(GuardNPC);
            }
        }

        else if (done == false)
        {
            if (StaticManager.stealpancakes && StaticManager.stealmoney == false)
            {
                anim.Play("stealpancake");
            }
            else if (StaticManager.stealpancakes && StaticManager.stealmoney == true)
            {
                StaticManager.NumDollars = 0;
                anim.Play("stealmoney");
            }
        }



    }
}
