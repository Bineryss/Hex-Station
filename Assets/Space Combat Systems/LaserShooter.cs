using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private GameObject Laser;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float cooldownTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > cooldown)
        {
            Shoot();
            cooldownTimer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(Laser, transform.position, transform.rotation);
    }
}
