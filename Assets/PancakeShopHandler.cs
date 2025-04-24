using UnityEngine;

public class PancakeShopHandler : MonoBehaviour
{

    void Update()
    {

        if (StaticManager.NumDollars > 20)
        {
            StaticManager.canbuypancake = true;
        }
        else
        {
            StaticManager.canbuypancake = false;
        }

    }
}
