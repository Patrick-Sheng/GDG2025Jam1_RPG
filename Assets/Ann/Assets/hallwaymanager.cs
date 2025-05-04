using UnityEngine;

public class hallwaymanager : MonoBehaviour
{
    public GameObject cam;
    public cameraMovementALL cammovesc;
    public GameObject Player;
    public GameObject fromdogpos;

    public GameObject fromgirlpos;
    void Start()
    {

        cammovesc.OutSideOfBounds();

        if (StaticManager.fromdoghall == true)
        {
            Player.transform.position = fromdogpos.transform.position;
            StaticManager.fromdoghall = false;
        }

        if (StaticManager.fromgirlroom == true)
        {
            //cam.transform.position = new Vector3(34.249f, 3.42f, -10f);
            Player.transform.position = fromgirlpos.transform.position;
            StaticManager.fromgirlroom = false;
        }
    }

}
