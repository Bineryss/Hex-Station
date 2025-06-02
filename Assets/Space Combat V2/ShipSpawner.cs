using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private WeaponData data;
    [SerializeField] private ShipData ship;

    void Start()
    {
        GameObject obj = Instantiate(ship.ShipPrefab);
        obj.GetComponent<WeaponController>().Configure(data);
    }

}
