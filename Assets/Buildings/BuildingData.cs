using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Buildings/Building")]
public class BuildingData : ScriptableObject
{
    [SerializeField] private string label;
    [SerializeField] private Sprite sprite;
    public List<Vector2Int> footprint;

}
