using UnityEngine;

public static class HexMetrics
{
    public const float outerRadius = 0.5f;
    public static readonly float innerRadius = outerRadius * (Mathf.Sqrt(3f) / 2f);

    public static readonly Vector3[] corners = {
        new Vector3(0f, outerRadius, 0f),
        new Vector3(innerRadius, 0.5f * outerRadius, 0f),
        new Vector3(innerRadius, -0.5f * outerRadius, 0f),
        new Vector3(0f, -outerRadius, 0f),
        new Vector3(-innerRadius, -0.5f * outerRadius, 0f),
        new Vector3(-innerRadius, 0.5f * outerRadius, 0f)
    };
}
