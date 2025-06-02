using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Game/WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int speed = 1;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private int damage = 1;

    public GameObject ProjectilePrefab => projectilePrefab;
    public int Speed => speed;
    public float FireRate => fireRate;
    public int Damage => damage;
}
