using Unity.VisualScripting.FullSerializer;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class HexagonGridLayout : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField] private Vector2Int gridSize;

    [Header("Tile Settings")]
    [SerializeField] private float size = 1f;
    [SerializeField] private float ringWidth = 0.1f;
    [SerializeField] private Material material;
    [SerializeField] private GameObject hexFab;


    private void OnEnable()
    {
        LayoutGrid();
    }

    private void LayoutGrid()
    {
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                GameObject tile = Instantiate(hexFab);

                tile.transform.position = GetPositionForHexFromCoordinate(new Vector2Int(x, y));

                HexRenderer hexRenderer = tile.GetComponent<HexRenderer>();
                hexRenderer.flatTopped = false;
                hexRenderer.innerSize = size - ringWidth;
                hexRenderer.outerSize = size;
                hexRenderer.material = material;
                hexRenderer.RenderMesh();

                tile.transform.SetParent(transform, true);
            }
        }
    }

    private Vector3 GetPositionForHexFromCoordinate(Vector2Int coordinate)
    {
        int column = coordinate.x;
        int row = coordinate.y;
        float width;
        float height;
        float horizontalDistance;
        float verticalDistance;
        bool shouldOffset;
        float offset;
        float xPosition;
        float yPosition;

        shouldOffset = row % 2 == 0;
        width = Mathf.Sqrt(3) * size;
        height = 2f * size;

        horizontalDistance = width;
        verticalDistance = height * (3f / 4f);

        offset = shouldOffset ? width / 2 : 0;

        xPosition = column * horizontalDistance + offset;
        yPosition = row * verticalDistance;

        return new Vector3(xPosition, -yPosition, 0);
    }
}
