using UnityEngine;
using UnityEngine.SceneManagement;

public class telleporttocutscene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && StaticManager.changePond)
        {
            SceneManager.LoadScene("FinalRoomTemp");
        }

    }
}
