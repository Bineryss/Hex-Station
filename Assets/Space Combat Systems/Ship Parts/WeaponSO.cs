using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Ships/Weapon")]
public class WeaponSO : ScriptableObject, ShipPart
{
    [Header("Stats")]
    // TODO add proper damage type SO
    [SerializeField] private string damageType;
    [SerializeField] private StatModifiers baseModifiers;

    [Header("Visual")]
    [SerializeField] private GameObject prefab;

    public StatModifiers BaseModifiers => baseModifiers;
    public GameObject Prefab => prefab;

}
