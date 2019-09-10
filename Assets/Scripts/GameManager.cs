using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [Range(0, 10)]
    public float startWaitSecondsForSharkFinToShowUpOrHide = 2.0f;
    [Range(0, 5)]
    public float waitSecondsForSharkFinToShowUpOrHide = 1.0f;

    // ParachutistSpawnController
    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float randomSpawning = 0.5f;
    [Range(0, 2)]
    public float changesTheSpeedOfManufactureOfClones = 0.98f;

    [SerializeField]
    SharkfinController sharkfinController;
    [SerializeField]
    SharkInWaterController sharkInWaterController;

    private ParachutistSpawnerController parachutistSpawnerController;
    [SerializeField]
    List<GameObject> missSharkPositions = new List<GameObject>();

    [SerializeField]
    TextMeshPro scoreAndClockText;
    [SerializeField]
    TextMeshPro missText;
    [SerializeField]
    TextMeshPro gameOverText;

    [HideInInspector]
    public int scoreValue;

    private int sharkIndex = -1;
    private int CurrentScore;
    private bool runClock = false;

    private void Start()
    {
        parachutistSpawnerController = GetComponent<ParachutistSpawnerController>();
    }

    private void Update()
    {
        IncreaseScore(scoreValue);

        if (runClock == true)
        {
            RunClock();
        }
    }

    private void OnEnable()
    {
        JoystickButtonInput.GameA += RestartGame;
        JoystickButtonInput.TimeMenu += ShowTime;
    }

    private void OnDisable()
    {
        JoystickButtonInput.GameA -= RestartGame;
        JoystickButtonInput.TimeMenu -= ShowTime;
    }

    // Tar in poäng från parachutistController och skriver ut poäng till scoreText
    void IncreaseScore(int score)
    {
        scoreAndClockText.text = score.ToString();
    }

    // Tar emot ett index när parachutist träffar vattnet som räknas som en miss och visar upp en haj
    // och när det blir game over då försvinner alla parachutist från skärmen
    public void ShowOrHideTheSharkWhenMissedTheBoat()
    {
        sharkIndex++;

        if (sharkIndex >= missSharkPositions.Count)
        {
            StopGame();
            gameOverText.text = "Game Over";
        }
        else 
        {
            missSharkPositions[sharkIndex].SetActive(true);
            missText.text = "Miss";
        } 
    }

    // Stoppar spelet, hajen och hajfenan som kommer upp ur vattnet
    void StopGame()
    {
        parachutistSpawnerController.Stop();
        sharkfinController.runSharkFin = false;
        sharkInWaterController.runShark = false;
    }

    public void ShowTime()
    {
        runClock = true;
        StopGame();
        Debug.Log("Time");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void RunClock()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);
        scoreAndClockText.text = hour + ":" + minute + ":" + second;
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
