using UnityEngine;

public class killgodong : MonoBehaviour
{
    public GameObject god;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (StaticManager.GODSHITDIDEND)
        {
            Destroy(god);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticManager.godDiologueEnd)
        {
            StaticManager.GODSHITDIDEND = true;
        }
        
    }
}
