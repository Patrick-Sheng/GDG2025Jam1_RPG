using UnityEngine;

public class WaterPour : MonoBehaviour  
{
    public bool hasWater = false;

    public void FillWater()
    {
        hasWater = true;
        Debug.Log("Fill Water!");
    }

    public void EmptyWater()
    {
        hasWater = false;
        Debug.Log("Empty Water!");
    }
}

