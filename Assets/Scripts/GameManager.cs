using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    ParachutistController parachutistController;
    //[SerializeField]
    //SharkfinController sharkfinController;
    private ParachutistSpawnerController parachutistSpawnerController;
    [SerializeField]
    List<GameObject> missSharkPositions = new List<GameObject>();

    [SerializeField]
    TextMeshPro scoreText;
    [SerializeField]
    TextMeshPro missText;
    [SerializeField]
    TextMeshPro gameOverText;

    // SharkfinController
    [Range(0, 10)]
    public float startWaitSecondsForSharkfinToShowUpOrHide = 2.0f;
    [Range(0, 5)]
    public float waitSecondsForSharkfinToShowUpOrHide = 1.0f;

    // ParachutistSpawnController
    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float randomSpawning = 0.5f;
    [Range(0, 2)]
    public float changesTheSpeedOfManufactureOfClones = 0.98f;

    [HideInInspector]
    public int scoreValue;
    //[HideInInspector]
    public int sharkIndex = -1;

    private void Start()
    {
        parachutistSpawnerController = GetComponent<ParachutistSpawnerController>();
    }

    private void Update()
    {
        IncreaseScore(scoreValue);
        ShowOrHideTheSharkWhenMissedTheBoat();
    }

    // Tar in poäng från parachutistController och skriver ut poäng till scoreText
    void IncreaseScore(int score)
    {
        scoreText.text = score.ToString();
    }

    // Tar emot ett index när parachutist träffar vattnet som räknas som en miss och visar upp en haj
    // och när det blir game over då försvinner alla parachutist från skärmen
    public void ShowOrHideTheSharkWhenMissedTheBoat()
    {
       //Debug.Log("Miss Shark " + sharkIndex);
        //TODO: Kolla varför den första hajen vissas

        missText.text = "Miss";

        if (sharkIndex >= missSharkPositions.Count)
        {
            parachutistSpawnerController.Stop();
            gameOverText.text = "Game Over";
        }
        else
        {
            missSharkPositions[sharkIndex].SetActive(true);
            
        }
            
    }
}
