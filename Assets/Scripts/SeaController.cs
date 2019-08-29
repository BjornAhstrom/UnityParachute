using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaController : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    //public SkydiverController skydiver;
    private int index = -1;
    private float nextUpdate = 0.0f;
    public float timeSpeed = 1.0f;

    private void Start()
    {
        
        //RestartGame();
    }

    private void Update()
    {
        if (Time.time > nextUpdate)
        {
            nextUpdate += timeSpeed;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {


        //Debug.Log("Water hit" + collision.gameObject.name);
       // MissBoat();
        index++;
        
        //skydiver.currentPosition = 0;
        Debug.Log("Index " + index);
        
    }

    private void MissBoat()
    {
        //for (int i = -1; i < 3; i++)
        //{
        //    positions[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //}

        if (index == 0)
        {
            positions[0].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (index == 1)
        {
            positions[1].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (index == 2)
        {
            positions[2].gameObject.GetComponent<SpriteRenderer>().enabled = true;

            Debug.Log("Game Over");
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    private void RestartGame()
    {
        positions[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        positions[1].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        positions[2].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ScoreController.scoreValue = 0;
        index = -1;
    }

}
