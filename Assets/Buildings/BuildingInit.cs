using System.Collections.Generic;
using UnityEngine;

public class BuildingInit : MonoBehaviour
{
    [SerializeField] private BuildingData data;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject footprint;


    void Start()
    {
        if (data == null) return;

        icon.GetComponent<SpriteRenderer>().sprite = data.BuildingIcon;
        footprint.GetComponent<SpriteRenderer>().sprite = data.Shape.Sprite;
        footprint.transform.SetPositionAndRotation(data.Shape.Position, Quaternion.identity);
    }

    public void SetData(BuildingData data)
    {
        this.data = data;
        icon.GetComponent<SpriteRenderer>().sprite = data.BuildingIcon;
        footprint.GetComponent<SpriteRenderer>().sprite = data.Shape.Sprite;
        footprint.transform.SetPositionAndRotation(data.Shape.Position, Quaternion.identity);
    }

    public List<HexCoordinates> GetFootprint()
    {
        return data.Shape.Footprint;
    }
}
