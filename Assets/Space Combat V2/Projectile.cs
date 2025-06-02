using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    public void Initialize(int dmg) => damage = dmg;

    void OnCollisionEnter(Collision col)
    {
        var target = col.collider.GetComponent<Damageable>();
        target?.TakeDamage(damage);
        Destroy(gameObject); //TODO add object pooling
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);//TODO add object pooling
    }

}
