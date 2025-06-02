using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HullSO", menuName = "Ships/Hull")]
public class HullSO : ScriptableObject, ShipPart
{
    [Header("Stats")]
    // TODO add proper damage type SO
    [SerializeField] private List<string> damageResistance;
    [SerializeField] private StatModifiers baseModifiers;

    [Header("Visual")]
    [SerializeField] private Sprite sprite;

    public StatModifiers BaseModifiers => baseModifiers;
    public Sprite Sprite => sprite;

}
