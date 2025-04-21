using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public List<HexCoordinates> shape = new List<HexCoordinates>() { new HexCoordinates(0, 0), new HexCoordinates(1, 0) };
    public HexCoordinates position;
    public Grid grid;
    public LineRenderer lineRenderer;
    public HexCoordinates center;

    public List<Vector3> lineVertices;

    void Update()
    {
        lineVertices.Clear();
        foreach (Vector3 vertex in HexMetrics.corners)
        {
            Vector3 worldPosition = grid.CellToWorld(center.ToOffsetCoordinates());
            lineVertices.Add(vertex + worldPosition);
        }
        lineRenderer.positionCount = lineVertices.Count;
        lineRenderer.SetPositions(lineVertices.ToArray());
    }
}
