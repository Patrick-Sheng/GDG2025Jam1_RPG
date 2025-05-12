using UnityEngine;

public class DESTORYPATRICK : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Patrick") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Patrick"));
        }
    }
}
