using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkydiverSpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject skydiverSpawnerPrefab;

    float lastSpawnTime;

    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float randomSpawning = 0.5f;

    private float randomSpawnDelay;

    private void Start()
    {
        if (skydiverSpawnerPrefab == null)
        {
            return;
        }
        randomSpawnDelay = spawnDelay;
        Skydiver();
    }

    private void Update()
    {
        if (Time.time > lastSpawnTime + randomSpawnDelay)
        {
            Skydiver();
        }
    }

    private void Skydiver()
    {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - randomSpawning, spawnDelay + randomSpawning);
        Instantiate(skydiverSpawnerPrefab);
    }
}
