using UnityEngine;

public class fadeaway2 : MonoBehaviour
{



    public SpriteRenderer sp;
    void Update()
    {
        if (StaticManager.fadeaway2)
        {
            
            
                Color c = sp.color;

                c.a -= (Time.deltaTime / 2);

                sp.color = c;

                if (c.a <= 0f)
                {
                    Destroy(gameObject);
                    
                }
            


        }
    }
}

