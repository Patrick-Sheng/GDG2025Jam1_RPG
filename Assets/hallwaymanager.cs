using UnityEngine;

public class hallwaymanager : MonoBehaviour
{
    public GameObject Player;
    public GameObject fromdogpos;

    public GameObject fromgirlpos;
    void Start()
    {
        if (StaticManager.fromdoghall == true)
        {
            Player.transform.position = fromdogpos.transform.position;
            StaticManager.fromdoghall = false;
        }

        if (StaticManager.fromgirlroom == true)
        {
            Player.transform.position = fromgirlpos.transform.position;
            StaticManager.fromgirlroom = false;
        }
    }

}
