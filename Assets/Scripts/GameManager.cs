using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    ParachutistController parachutistController;
    private ParachutistSpawnerController parachutistSpawnerController;
    [SerializeField]
    List<GameObject> missSharkPositions = new List<GameObject>();

    [SerializeField]
    TextMeshPro scoreText;
    [SerializeField]
    TextMeshPro missText;
    [SerializeField]
    TextMeshPro gameOverText;

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

    // Tar emot ett index när parachutist träffar vattnet som räknas wom en miss och visar upp en haj
    public void ShowOrHideTheSharkWhenMissedTheBoat()
    {
        Debug.Log("Miss Shark " + sharkIndex);
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
