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

    // public static HexCoordinates FromPosition(Vector3 position)
    // {
    //     float x = position.x / (HexMetrics.innerRadius * 2f);
    //     float y = -x;

    //     float offset = position.z / (HexMetrics.outerRadius * 3f);
    //     x -= offset;
    //     y -= offset;

    //     int iX = Mathf.RoundToInt(x);
    //     int iY = Mathf.RoundToInt(y);
    //     int iZ = Mathf.RoundToInt(-x - y);

    //     if (iX + iY + iZ != 0)
    //     {
    //         float dX = Mathf.Abs(x - iX);
    //         float dY = Mathf.Abs(y - iY);
    //         float dZ = Mathf.Abs(-x - y - iZ);

    //         if (dX > dY && dX > dZ)
    //         {
    //             iX = -iY - iZ;
    //         }
    //         else if (dZ > dY)
    //         {
    //             iZ = -iX - iY;
    //         }
    //     }

    //     return new HexCoordinates(iX, iZ);
    // }
}