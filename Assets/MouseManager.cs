using TMPro;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Vector2 mouse = new Vector2(0, 0);
    public HexCoordinates hexCords;
    public Vector3Int gridCoords;
    public Vector3Int offsetCoords;
    public HexGrid hexGrid;
    public GameObject buildingPrefab;
    public BuildingData buildingData;

    private GameObject building;
    void Start()
    {
        building = InstantiateBuilding();
    }

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
        hexGrid.MoveElement(mouseWorldPos, building);

        if (Input.GetMouseButton(0))
        {
            BuildingInit buildingInit = building.GetComponent<BuildingInit>();

            bool placed = hexGrid.AddElement(mouseWorldPos, buildingInit);
            if (placed)
            {
                building = InstantiateBuilding();
            }
        }
    }

    GameObject InstantiateBuilding()
    {
        GameObject instance = Instantiate(buildingPrefab);
        instance.GetComponent<BuildingInit>().SetData(buildingData);
        return instance;
    }
}
