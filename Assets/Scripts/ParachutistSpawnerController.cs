using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutistSpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject skydiverSpawnerPrefab;
    GameManager gameManager;

    private List<GameObject> parachutist = new List<GameObject>();
    
    private float lastSpawnTime;

    private float randomSpawnDelay;
    private bool stop = false;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        if (skydiverSpawnerPrefab == null)
        {
            return;
        }
        randomSpawnDelay = gameManager.spawnDelay;
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
        lastSpawnTime *= gameManager.changesTheSpeedOfManufactureOfClones; 
        randomSpawnDelay = Random.Range(gameManager.spawnDelay - gameManager.randomSpawning, gameManager.spawnDelay + gameManager.randomSpawning);

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

    public void Stop()
    {
        stop = true;

        // Gå igenom listan nerifrån och förstör alla Parachutist
        for (int i = parachutist.Count - 1; i >= 0; i--)
        {
            DestroySpawnerCloneObject(parachutist[i]);
        }
    }
}
