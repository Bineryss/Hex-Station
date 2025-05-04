using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private GameObject Laser;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private int bulletChance = 50;
    [SerializeField] private bool random;

    private float cooldownTimer = 0f;
    private System.Random rng;
    private bool startTimer;

    // void OnBecameVisible()
    // {
    //     startTimer = true;
    // }

    void Start()
    {
        rng = new System.Random(GetInstanceID());
        cooldownTimer = (float)rng.NextDouble() * cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!startTimer) return;

        cooldownTimer += Time.deltaTime;
        if (cooldownTimer < cooldown) return;
        if (random && rng.Next(0, 100) > bulletChance) return;

        Shoot();
        cooldownTimer = 0;
    }

    void Shoot()
    {
        Instantiate(Laser, transform.position, transform.rotation);
    }
}
