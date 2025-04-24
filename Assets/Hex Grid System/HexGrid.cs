using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private HexCoordinates position;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int radius = 2;

    private Dictionary<HexCoordinates, BuildingInit> tiles;
    private readonly Dictionary<HexCoordinates, GameObject> background = new();
    void Start()
    {
        tiles = new Dictionary<HexCoordinates, BuildingInit>(new MyKeyComparer());
        // CreateRing(size);
    }

    void Update()
    {
        DrawHexBackground();
    }

    void DrawHexBackground()
    {
        foreach (GameObject goo in background.Values)
        {
            Destroy(goo);
        }
        background.Clear();

        for (int q = -radius; q <= radius; q++)
        {
            int r1 = Mathf.Max(-radius, -q - radius);
            int r2 = Mathf.Min(radius, -q + radius);
            for (int r = r1; r <= r2; r++)
            {
                HexCoordinates coordinates = new HexCoordinates(q, r);
                Color color = Color.white;
                if (coordinates.Q == 0 && coordinates.R != 0 && coordinates.S != 0)
                {
                    color = Color.green;
                }
                if (coordinates.R == 0 && coordinates.Q != 0 && coordinates.S != 0)
                {
                    color = Color.blue;
                }
                if (coordinates.S == 0 && coordinates.R != 0 && coordinates.Q != 0)
                {
                    color = Color.red;
                }
                if (coordinates.S == 0 && coordinates.R == 0 && coordinates.Q == 0)
                {
                    color = Color.white;
                }

                color.a = 0.1f;

                CreateCell(coordinates, color);
            }
        }
    }

    void CreateCell(HexCoordinates position, Color color)
    {
        if (background.ContainsKey(position))
        {
            Debug.Log($"Tile already exists for {position}");
            return;
        }

        var offsetCoords = position.ToOffsetCoordinates();
        var worldPosition = grid.GetCellCenterWorld(offsetCoords);
        worldPosition += new Vector3(0, 0, -1);

        GameObject tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity);
        tile.name = $"Hex_{position}";

        tile.GetComponent<SpriteRenderer>().color = color;

        TMP_Text text = tile.GetComponentInChildren<TMP_Text>();
        text.text = position.ToStringOnSeparateLines();

        if (tiles.ContainsKey(position))
        {
            text.color = new Color(1f, 0f, 0f, 0.5f);
        }

        background.Add(position, tile);
    }

    public bool AddElement(Vector3 target, BuildingInit element)
    {
        bool isBlocked = false;
        List<HexCoordinates> footprint = element.GetFootprint();
        List<HexCoordinates> footprintWithOffset = new();
        foreach (HexCoordinates coord in footprint)
        {
            HexCoordinates cordWithOffset = CalculateOffsetPosition(target, coord);
            isBlocked = isBlocked || tiles.ContainsKey(cordWithOffset);
            footprintWithOffset.Add(cordWithOffset);
            Debug.Log($"calculated offset:{cordWithOffset}, is in dictionary:{tiles.ContainsKey(cordWithOffset)}");
        }

        if (isBlocked)
        {
            Debug.Log("Cannot Place Building here!");
            return false;
        }

        foreach (HexCoordinates coord in footprintWithOffset)
        {
            tiles.Add(coord, element);
        }

        Vector3Int offsetCoords = grid.WorldToCell(target);
        Vector3 worldPosition = grid.GetCellCenterWorld(offsetCoords);

        element.transform.SetPositionAndRotation(worldPosition, Quaternion.identity);
        return true;
    }

    HexCoordinates CalculateOffsetPosition(Vector3 position, HexCoordinates offset)
    {
        Vector3Int offsetCoord = grid.WorldToCell(position);
        HexCoordinates offsetHex = HexCoordinates.FromOffsetCoordinates(offsetCoord.x, offsetCoord.y);
        HexCoordinates calculatedOffset = offset + offsetHex;
        Debug.Log($"offset for position:{position} and offset:{offset} at {calculatedOffset}");
        return calculatedOffset;
    }

    public void MoveElement(Vector3 target, GameObject element)
    {
        Vector3Int offsetCoord = grid.WorldToCell(target);
        Vector3 coord = grid.CellToWorld(offsetCoord);
        element.transform.SetPositionAndRotation(coord, Quaternion.identity);
    }
}

public class MyKeyComparer : IEqualityComparer<HexCoordinates>
{
    public bool Equals(HexCoordinates x, HexCoordinates y)
    {
        // Compare based on a property, e.g., x.Id == y.Id
        return x.Q == y.Q && x.R == y.R;
    }

    public int GetHashCode(HexCoordinates obj)
    {
        // Use the same property for hash code
        return (obj.Q, obj.R).GetHashCode();
    }
}
