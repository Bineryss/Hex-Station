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
        return data.Shape.Footprint;
    }

    public void RotateClockwise()
    {
        rotation += 60;
        rotation %= 360;
        // Debug.Log($"rotate to {rotation}");
        transform.rotation = Quaternion.AngleAxis(-rotation, Vector3.forward);
        icon.transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.forward);
    }
}
