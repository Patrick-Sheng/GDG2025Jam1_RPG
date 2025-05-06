using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wait2seconds : MonoBehaviour
{
    private float timer = 3f;
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("heavenMain");
        }
    }
}
