using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);

    //}

    // Update is called once per frame
    void nextscene()
    {
        print(StaticManager.nextScene);
        SceneManager.LoadScene(StaticManager.nextScene);
    }
}
