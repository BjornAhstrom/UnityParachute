using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutistSpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject skydiverSpawnerPrefab;
    private List<GameObject> parachutist = new List<GameObject>();
    
    private float lastSpawnTime;
    
    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float randomSpawning = 0.5f;
    [Range(0, 2)]
    public float changesTheSpeedOfManufactureOfClones = 0.98f;

    private float randomSpawnDelay;
    private bool stop = false;

    private void Start()
    {
        if (skydiverSpawnerPrefab == null)
        {
            return;
        }
        randomSpawnDelay = spawnDelay;
        SpawnParachutist();
    }

    private void Update()
    {
        if (!stop && Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnParachutist();
        }
    }

    private void SpawnParachutist()
    {
        lastSpawnTime = Time.time;

        // Ökar eller sänker hastigheten av tillverkning av cloner
        lastSpawnTime *= changesTheSpeedOfManufactureOfClones; 
        randomSpawnDelay = Random.Range(spawnDelay - randomSpawning, spawnDelay + randomSpawning);

        // Skapar Parachutist clone
        GameObject parachute =  Instantiate(skydiverSpawnerPrefab);

        // Lägger till clonen i listan
        parachutist.Add(parachute);
        ParachutistController parachutistController = parachute.GetComponentInChildren<ParachutistController>();

        parachutistController.parachutistSpawner = this;
    }

    void DestroySpawnerCloneObject(GameObject parach)
    {
        // Ta bort parachutist från listan
        parachutist.Remove(parach);

        // Förstör Parachutist
        Destroy(parach);
    }

    void Stop()
    {
        stop = true;

        // Gå igenom listan nerifrån och förstör alla Parachutist
        for (int i = parachutist.Count - 1; i >= 0; i--)
        {
            DestroySpawnerCloneObject(parachutist[i]);
        }
    }
}
