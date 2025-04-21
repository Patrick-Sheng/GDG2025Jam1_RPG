using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [Header("Data")]
    public int Level;
    public Sprite icon;

    [Header("Value")]
    public float CurrentHealth;
    public float MaxHealth;
    public float Energy;

}
