using System.Collections.Generic;
using UnityEngine;

//TODO: https://www.youtube.com/watch?v=0nXmuJuWS8I

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class HexRenderer : MonoBehaviour
{
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private List<Face> faces;

    [SerializeField] public Material material;
    [SerializeField] public float innerSize = 0f;
    [SerializeField] public float outerSize = 1f;
    [SerializeField] public bool flatTopped;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        mesh = new Mesh();
        mesh.name = "hex";

        meshFilter.mesh = mesh;
        meshRenderer.material = material;
    }

    private void OnEnable()
    {
        RenderMesh();
    }

    public void RenderMesh()
    {
        RenderFaces();
        CombineFaces();
    }

    private void RenderFaces()
    {
        faces = new List<Face>();

        for (int point = 0; point < 6; point++)
        {
            faces.Add(CreateFace(innerSize, outerSize, point));
        }
    }

    private void CombineFaces()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < faces.Count; i++)
        {
            Face face = faces[i];
            vertices.AddRange(face.vertices);
            uvs.AddRange(face.uvs);

            int offset = 4 * i;
            foreach (int triangle in face.triangles)
            {
                triangles.Add(triangle + offset);
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();
    }

    private Face CreateFace(float innerRad, float outerRad, int point)
    {
        Vector3 pointA = GetPoint(innerRad, point);
        Vector3 pointB = GetPoint(innerRad, (point < 5) ? point + 1 : 0);
        Vector3 pointC = GetPoint(outerRad, (point < 5) ? point + 1 : 0);
        Vector3 pointD = GetPoint(outerRad, point);

        List<Vector3> vertices = new List<Vector3>() { pointA, pointB, pointC, pointD };
        List<int> triangles = new List<int>() { 0, 1, 2, 2, 3, 0 };
        List<Vector2> uvs = new List<Vector2>() { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };


        return new Face(vertices, triangles, uvs);
    }

    private Vector3 GetPoint(float size, int index)
    {
        float angleDeg = flatTopped ? 60 * index : 60 * index - 30;
        float angleRad = Mathf.PI / 180f * angleDeg;
        return new Vector3(size * Mathf.Cos(angleRad), size * Mathf.Sin(angleRad), 0);
    }
}

public struct Face
{
    public List<Vector3> vertices { get; private set; }
    public List<int> triangles { get; private set; }
    public List<Vector2> uvs { get; private set; }

    public Face(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs)
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.uvs = uvs;
    }

}
