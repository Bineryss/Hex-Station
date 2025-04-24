using UnityEngine;

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

    public HexCoordinates(int q, int r)
    {
        this.q = q;
        this.r = r;
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
}