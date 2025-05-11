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

    public GameObject fromgirl;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("moneyholder") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("moneyholder"));
        }

    }
    void Start()
    {



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
                cam.transform.position = fromgirl.transform.position;
                StaticManager.fromgirlroom = false;
            }
            if (StaticManager.YellowToHall == true)
            {
                cam.transform.position = fromgirl.transform.position;
                StaticManager.YellowToHall = false;
                Player.transform.position = fromYellow.transform.position;
            }
        }

    }

