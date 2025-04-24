using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingInit : MonoBehaviour
{
    [SerializeField] private BuildingData data;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject footprint;

    private int rotation = 0;
    void Start()
    {
        if (data == null) return;

        icon.GetComponent<SpriteRenderer>().sprite = data.BuildingIcon;
        footprint.GetComponent<SpriteRenderer>().sprite = data.Shape.Sprite;
        footprint.transform.localPosition = data.Shape.Position;
    }

    public void SetData(BuildingData data)
    {
        this.data = data;
        icon.GetComponent<SpriteRenderer>().sprite = data.BuildingIcon;
        footprint.GetComponent<SpriteRenderer>().sprite = data.Shape.Sprite;
        footprint.transform.localPosition = data.Shape.Position;
    }

    public List<HexCoordinates> GetFootprint()
    {
        List<HexCoordinates> coords = data.Shape.Footprint;
        List<HexCoordinates> rotatetCords = new();

        foreach (HexCoordinates coord in coords)
        {
            HexCoordinates rotatetCord = coord;
            for (int i = 0; i < rotation; i++)
            {
                rotatetCord = rotatetCord.Rotate();
            }
            rotatetCords.Add(rotatetCord);
        }

        return rotatetCords;
    }

    public void RotateClockwise()
    {
        rotation++;
        rotation %= 6;
        Debug.Log($"rotate to {rotation * 60}");
        transform.rotation = Quaternion.AngleAxis(-rotation * 60, Vector3.forward);
        icon.transform.localRotation = Quaternion.AngleAxis(rotation * 60, Vector3.forward);
    }
}
