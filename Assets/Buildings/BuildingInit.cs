using Unity.VisualScripting;
using UnityEngine;

public class BuildingInit : MonoBehaviour
{
    [SerializeField] private BuildingData data;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject footprint;


    void Start()
    {
        icon.GetComponent<SpriteRenderer>().sprite = data.BuildingIcon;
        footprint.GetComponent<SpriteRenderer>().sprite = data.Shape.Sprite;
        footprint.transform.SetPositionAndRotation(data.Shape.Position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
