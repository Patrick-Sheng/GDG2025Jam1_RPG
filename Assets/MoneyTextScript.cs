using UnityEngine;
using UnityEngine.UI;

public class MoneyTextScript : MonoBehaviour
{
    public Text thisText;

    void Update()
    {
        thisText.text = StaticManager.NumDollars.ToString();

    }
}
