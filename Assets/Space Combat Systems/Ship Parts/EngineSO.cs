using UnityEngine;

[CreateAssetMenu(fileName = "EngineSO", menuName = "Ships/Engine")]
public class EngineSO : ScriptableObject, ShipPart
{
    [Header("Stats")]
    [SerializeField] private StatModifiers baseModifiers;
    [Header("Visuals")]
    [SerializeField] private Sprite sprite;

    public StatModifiers BaseModifiers => baseModifiers;
    public Sprite Sprite => sprite;
}
