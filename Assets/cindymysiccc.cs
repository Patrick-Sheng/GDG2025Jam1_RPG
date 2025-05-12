using UnityEngine;

public class cindymysiccc : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("AnnRoomSound") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("AnnRoomSound"));
        }
    }
}
