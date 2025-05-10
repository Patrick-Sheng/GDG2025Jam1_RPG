using UnityEngine;

public class fadeaway : MonoBehaviour
{
    public SpriteRenderer sp;
    void Update()
    {
        if (StaticManager.fadeaway)
        {
            if (StaticManager.stickmangone == false)
            {
                Color c = sp.color;

                c.a -= (Time.deltaTime / 2);

                sp.color = c;

                if (c.a <= 0f)
                {
                    Destroy(gameObject);
                    StaticManager.stickmangone = true;
                }
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
