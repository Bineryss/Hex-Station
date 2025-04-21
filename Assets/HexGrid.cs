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

        //n ringe erzeugen - n = size
        // pro ring muss ein wert der hex coords = n sein, 
        // alle anderen müssen alle möglichen variation haben

        // for (int radialStep = 0; radialStep < size; radialStep++)
        // {
        //     for (int step = -radialStep * 6; step < radialStep * 6; step++)
        //     {
        //         CreateCell(new HexCoordinates(step, 0));
        //     }
        // }

        CreateCell(new HexCoordinates(0, 0));
        for (int x = -size; x <= size; x++)
        {
            CreateCell(new HexCoordinates(x, 0));
        }
        for (int x = -size; x <= size; x++)
        {
            CreateCell(new HexCoordinates(0, x));
        }
        for (int x = -size; x <= size; x++)
        {
            CreateCell(new HexCoordinates(x, -x));
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (tiles.Count == 0) return;

    //     var worldPosition = grid.GetCellCenterWorld(position.ToOffsetCoordinates());
    //     // Debug.Log($"Grid position: {position} -> World position: {worldPosition}");
    //     tiles[0].transform.position = worldPosition;
    // }

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
