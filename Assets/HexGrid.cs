using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private HexCoordinates position;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int size = 2;
    [SerializeField] private List<GameObject> buildings;

    private Dictionary<HexCoordinates, GameObject> tiles;
    public GameObject nextBuilding;
    void Start()
    {
        tiles = new Dictionary<HexCoordinates, GameObject>();
        nextBuilding = Instantiate(tilePrefab);
        CreateRing(size);
    }

    // void OnValidate()
    // {
    //     if (!Application.isPlaying) return;
    //     if (tiles.Count == 0) return;

    //     foreach (GameObject tile in tiles.Values)
    //     {
    //         Destroy(tile);
    //     }
    //     tiles.Clear();

    //     CreateRing(size);
    // }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
            Debug.Log("mouse clicked");
        }
    }

    void HandleInput()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPos = Input.mousePosition;

        // Set the z value to zero (for 2D scenes)
        mouseScreenPos.z = 0f;

        // Convert to world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // Optionally, set z to zero again if you want a pure 2D position
        mouseWorldPos.z = 0f;

        Debug.Log(mouseWorldPos.ToString());

        Vector3Int gridCoords = grid.WorldToCell(mouseWorldPos);
        CreateCell(HexCoordinates.FromOffsetCoordinates(gridCoords.x, gridCoords.y), Color.magenta);
    }

    void CreateRing(int radius)
    {
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


                CreateCell(coordinates, color);
            }
        }
    }

    void CreateCell(HexCoordinates position, Color color)
    {
        if (tiles.ContainsKey(position))
        {
            Debug.Log($"Tile alreaddy exists for {position}");
            return;
        }

        var offsetCoords = position.ToOffsetCoordinates();
        var worldPosition = grid.GetCellCenterWorld(offsetCoords);
        Debug.Log($"Grid position: {position} | {offsetCoords} -> World position: {worldPosition}");

        int randomIndex = Random.Range(0, buildings.Count);


        GameObject tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity);
        tile.name = $"Hex_{position}";
        nextBuilding = tile;

        tile.GetComponent<SpriteRenderer>().color = color;

        // tile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = buildings[randomIndex];
        tile.GetComponentInChildren<TMP_Text>().text = position.ToStringOnSeparateLines();

        tiles.Add(position, tile);
    }
}
