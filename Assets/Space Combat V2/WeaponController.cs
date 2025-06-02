using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;

    private WeaponMount[] mounts;
    private bool isFiring;
    void Awake()
    {
        mounts = GetComponentsInChildren<WeaponMount>();
    }

    public void Configure(WeaponData data)
    {
        weaponData = data;
        if (!isFiring) StartCoroutine(FireRoutine());
    }

    private IEnumerator FireRoutine()
    {
        isFiring = true;
        var wait = new WaitForSeconds(1f / weaponData.FireRate);
        while (true)
        {
            foreach (var mount in mounts)
            {
                SpawnProjectile(mount.FirePoint);
            }
            yield return wait;
        }
    }

    void SpawnProjectile(Transform firePoint)
    {
        //TODO: add object pooling!
        var proj = Instantiate(weaponData.ProjectilePrefab,
                                    firePoint.position,
                                    firePoint.rotation);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * weaponData.Speed;
        proj.GetComponent<Projectile>().Initialize(weaponData.Damage);
    }

}
