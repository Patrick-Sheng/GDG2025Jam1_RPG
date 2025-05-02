using UnityEngine;
using UnityEngine.SceneManagement;

public class TestArcadeButtons : MonoBehaviour
{
    public void YouLose()
    {
        SceneManager.LoadScene("heavenMain");
        StaticManager.YouLoseArcade = true;
    }
    public void YouWin()
    {
        SceneManager.LoadScene("heavenMain");
        StaticManager.YouWinArcade = true;
    }
}
