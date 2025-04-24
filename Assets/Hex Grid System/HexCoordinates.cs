using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct HexCoordinates
{

    [SerializeField]
    private int q, r;

    public int Q // \
    {
        get
        {
            return q;
        }
    }
    public int R // -
    {
        get
        {
            return r;
        }
    }
    public int S // /
    {
        get
        {
            return -Q - R;
        }
    }
    public static HexCoordinates operator +(HexCoordinates h1, HexCoordinates h2)
    {
        return new HexCoordinates(h1.Q + h2.Q, h1.R + h2.R);
    }
    public static HexCoordinates operator -(HexCoordinates h1, HexCoordinates h2)
    {
        return new HexCoordinates(h1.Q - h2.Q, h1.R - h2.R);
    }

    public HexCoordinates(int q, int r)
    {
        this.q = q;
        this.r = r;
    }
    public HexCoordinates Rotate(HexCoordinates center = default, bool counterClockwise = false)
    {
        // Convert to relative coordinates
        HexCoordinates relative = this - center;

        // Apply rotation
        HexCoordinates rotatedRelative = counterClockwise ?
            new HexCoordinates(-relative.R, relative.Q + relative.R) :
            new HexCoordinates(relative.Q + relative.R, -relative.Q);

        // Convert back to absolute coordinates
        return rotatedRelative + center;
    }
    public static HexCoordinates FromOffsetCoordinates(int x, int y)
    {
        return new HexCoordinates(x - Mathf.FloorToInt((float)y / 2), y);
    }
    public Vector3Int ToOffsetCoordinates()
    {
        int x = Q + ((R - (R & 1)) / 2);
        int y = R;
        return new Vector3Int(x, y, 0);
    }
    public override string ToString()
    {
        return $"(Q {Q},R {R},S {S})";
    }
    public string ToStringOnSeparateLines()
    {
        return $"Q:{Q}\nR:{R}\nS:{S}";
        // Vector3Int offset = ToOffsetCoordinates();
        // return $"{offset.x};{offset.y}";
    }

    public bool Equals(HexCoordinates h1, HexCoordinates h2)
    {
        return h1.Q == h2.Q && h1.R == h2.R;
    }

    public int GetHashCode(HexCoordinates obj)
    {
        return (obj.Q, obj.R).GetHashCode();
    }
}