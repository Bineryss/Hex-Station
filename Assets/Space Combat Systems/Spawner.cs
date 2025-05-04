using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemys;
    [SerializeField] private List<GameObject> astroids;
    [SerializeField] private float waveCooldown = 2f;
    [SerializeField] private float waveTimer;
    [SerializeField] private int wave;
    [SerializeField] private int waveMultiplyer = 1;
    [SerializeField] private int maxEnemys = 20;

    private float right;
    private float left;
    void Start()
    {
        float camHeight = Camera.main.orthographicSize * 2f;
        float camWidth = camHeight * Camera.main.aspect;

        left = Camera.main.transform.position.x - camWidth / 2;
        right = Camera.main.transform.position.x + camWidth / 2;
        StartWave(0);
    }

    void Update()
    {
        waveTimer += Time.deltaTime;
        if (waveTimer < waveCooldown) return;

        waveTimer = 0;
        wave++;
        StartWave(wave);
    }

    void StartWave(int wave)
    {
        int enemyCount = Math.Min(maxEnemys, UnityEngine.Random.Range(0, wave) * waveMultiplyer);

        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemys[UnityEngine.Random.Range(0, enemys.Count)], new Vector3(UnityEngine.Random.Range(left, right), transform.position.y), Quaternion.Euler(0f, 0f, 180f));
        }
    }
}
