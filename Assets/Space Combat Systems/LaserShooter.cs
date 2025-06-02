using System.Collections;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private GameObject Laser;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private int bulletChance = 50;
    [SerializeField] private bool random;
    [SerializeField] private int salvoCount = 3;
    [SerializeField] private float salvoDelay = 0.1f;

    private float cooldownTimer = 0f;
    private System.Random rng;

    void Start()
    {
        rng = new System.Random(GetInstanceID());
        cooldownTimer = (float)rng.NextDouble() * cooldown;
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer < cooldown) return;
        if (random && rng.Next(0, 100) > bulletChance) return;

        StartCoroutine(ShootSalvo());
        cooldownTimer = 0;
    }


    IEnumerator ShootSalvo()
    {
        for (int i = 0; i < salvoCount; i++)
        {
            Instantiate(Laser, transform.position, transform.rotation);
            if (i < salvoCount - 1)
            {
                yield return new WaitForSeconds(salvoDelay);
            }
        }
    }
}
