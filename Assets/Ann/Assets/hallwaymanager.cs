using UnityEngine;

public class hallwaymanager : MonoBehaviour
{
    public GameObject cam;
    public cameraMovementALL cammovesc;
    public GameObject Player;
    public GameObject fromdogpos;

    public GameObject fromgirlpos;
    public GameObject fromYellow;
    public GameObject Lockeddoor;
    void Start()
    {
        if ( GameObject.FindGameObjectWithTag("moneyholder") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("moneyholder"));

        }

        if (StaticManager.haswordleKey)
        {
            Lockeddoor.SetActive(false);
        }

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
        if (StaticManager.YellowToHall == true)
        {
            StaticManager.YellowToHall = false;
            Player.transform.position = fromYellow.transform.position;
        }
    }

}
