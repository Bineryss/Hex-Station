using UnityEngine;

public static class HexMetrics
{
    public const float outerRadius = 1f;
    public static readonly float innerRadius = outerRadius * (Mathf.Sqrt(3f) / 2f);

    public static readonly Vector3[] corners = {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius)
    };
}
