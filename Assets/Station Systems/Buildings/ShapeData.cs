using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShapeData", menuName = "Buildings/ShapeData")]
public class ShapeData : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string shapeName;
    [SerializeField] private List<HexCoordinates> footprint = new List<HexCoordinates>();
    [SerializeField] private Vector2Int spriteOffsetHexagons = new Vector2Int(1, 2);
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }
    public Vector3 Position
    {
        get
        {
            return CalculatePosition();
        }
    }
    public List<HexCoordinates> Footprint
    {
        get
        {
            return footprint;
        }
    }
    public string ShapeName
    {
        get
        {
            return shapeName;
        }
    }


    private Vector3 CalculatePosition()
    {
        return new Vector3(
            -HexMetrics.innerRadius * spriteOffsetHexagons.x,
            -HexMetrics.outerRadius / 2 * spriteOffsetHexagons.y, 0);
    }
}
