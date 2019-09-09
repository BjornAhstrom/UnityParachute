using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    ParachutistController parachutistController;
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
    [HideInInspector]
    public int sharkIndex = - 1;

    private void Start()
    {
        
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

    public void ShowOrHideTheSharkWhenMissedTheBoat()
    {
        if (sharkIndex >= missSharkPositions.Count)
        {
            gameOverText.text = "Game Over";
        }
        else
        {
            missSharkPositions[sharkIndex].SetActive(true);
        }
            
    }
}
