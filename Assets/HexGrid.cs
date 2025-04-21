using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private HexCoordinates position;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int size = 2;
    [SerializeField] private List<Sprite> buildings;

    private Dictionary<HexCoordinates, GameObject> tiles;
    void Start()
    {
        tiles = new Dictionary<HexCoordinates, GameObject>();
        CreateRing(size);
    }

    void CreateRing(int radius)
    {
        for (int q = -radius; q <= radius; q++)
        {
            int r1 = Mathf.Max(-radius, -q - radius);
            int r2 = Mathf.Min(radius, -q + radius);
            for (int r = r1; r <= r2; r++)
            {
                CreateCell(new HexCoordinates(q, r));
            }
        }
    }

    void CreateCell(HexCoordinates position)
    {
        if (tiles.ContainsKey(position)) return;

        var offsetCoords = position.ToOffsetCoordinates();
        var worldPosition = grid.GetCellCenterWorld(offsetCoords);
        Debug.Log($"Grid position: {position} | {offsetCoords} -> World position: {worldPosition}");

        GameObject tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity);
        Debug.Log(tile.transform.position);
        tile.name = $"Hex_{position}";
        int randomIndex = Random.Range(0, buildings.Count);

        if (position.Q == 0 && position.R != 0 && position.S != 0)
        {
            tile.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (position.R == 0 && position.Q != 0 && position.S != 0)
        {
            tile.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (position.S == 0 && position.R != 0 && position.Q != 0)
        {
            tile.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (position.S == 0 && position.R == 0 && position.Q == 0)
        {
            tile.GetComponent<SpriteRenderer>().color = Color.white;
        }


        tile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = buildings[randomIndex];
        tile.GetComponentInChildren<TMP_Text>().text = position.ToStringOnSeparateLines();

        tiles.Add(position, tile);
    }
}
