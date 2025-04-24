using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public Vector2 mouse = new Vector2(0, 0);
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
    }


    public void PlaceBuilding()
    {
        bool placed = hexGrid.AddElement(mouse, building.GetComponent<BuildingInit>());
        if (placed)
        {
            building = InstantiateBuilding();
        }
    }

    public void RotateBuilding(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        building.GetComponent<BuildingInit>().RotateClockwise();
    }

    GameObject InstantiateBuilding()
    {
        GameObject instance = Instantiate(buildingPrefab);
        instance.GetComponent<BuildingInit>().SetData(buildingData);
        return instance;
    }
}
