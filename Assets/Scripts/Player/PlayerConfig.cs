using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [Header("Data")]
    public int Level;
    public Sprite icon;

    [Header("Value")]
    public int CurrentHealth;
    public int MaxHealth;
    public float Energy;

}
