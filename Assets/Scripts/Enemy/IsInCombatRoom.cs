using UnityEngine;

public class IsInCombatRoom : MonoBehaviour
{
    private BoxCollider2D roomCollider;
    void Start()
    {
        roomCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
