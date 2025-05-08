using UnityEngine;

public class fishvisualchanger : MonoBehaviour
{
    private SpriteRenderer sp;
    public Sprite empty;
    public Sprite part1;
    public Sprite part2;
    public Sprite full;
    private void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (StaticManager.fulltank == 1)
        {
            sp.sprite = part2;
        }
        else if (StaticManager.fulltank == 2)
        {
            sp.sprite = full;
        }
        else if (StaticManager.tankisfull == true)
        {
           
        }
        else
        {
            sp.sprite = empty;
        }
    }
}
