using TMPro;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Vector2 mouse = new Vector2(0, 0);
    public HexCoordinates hexCords;
    public Vector3Int gridCoords;
    public Vector3Int offsetCoords;
    public Grid grid;
    public HexGrid hexGrid;

    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;

        // Set the z value to zero (for 2D scenes)
        mouseScreenPos.z = 0f;

        // Convert to world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // Optionally, set z to zero again if you want a pure 2D position
        mouseWorldPos.z = 0f;
        mouse.x = mouseWorldPos.x;
        mouse.y = mouseWorldPos.y;
        gridCoords = grid.WorldToCell(mouseWorldPos);

        hexCords = HexCoordinates.FromOffsetCoordinates(gridCoords.x, gridCoords.y);
        offsetCoords = hexCords.ToOffsetCoordinates();
        hexGrid.nextBuilding.transform.SetPositionAndRotation(grid.GetCellCenterWorld(offsetCoords), Quaternion.identity);

        // hexGrid.nextBuilding.GetComponentInChildren<TMP_Text>().text = hexCords.ToStringOnSeparateLines();
    }
}
