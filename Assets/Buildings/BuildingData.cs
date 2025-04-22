using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Buildings/Building")]
public class BuildingData : ScriptableObject
{
    [SerializeField] private string label;
    [SerializeField] private Sprite icon;
    [SerializeField] private ShapeData shape;

    public Sprite BuildingIcon
    {
        get
        {
            return icon;
        }
    }
    public ShapeData Shape
    {
        get
        {
            return shape;
        }
    }
}
