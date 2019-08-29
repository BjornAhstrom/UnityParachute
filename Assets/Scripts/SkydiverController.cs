﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkydiverController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positions = new List<Transform>();

    public int currentPosition = 0;
    private float nextUpdate;
    float timeSpeed = 1.0f;

    private void Start()
    {
        transform.position = positions[currentPosition].position;
        nextUpdate = Time.time;
        
    }

    private void Update()
    {
        if (Time.time > nextUpdate + timeSpeed)
        {
            MoveSkydiverToNextPosition();
            nextUpdate = Time.time;
        }
    }

    private void MoveSkydiverToNextPosition()
    {
        currentPosition++;

        if (currentPosition >= positions.Count)
        {
            //DestroySkydiver();
        } else
        {
            transform.position = positions[currentPosition].position;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.name.Equals("Boat"))
        {
            Debug.Log("Boat");
            //GameManager.scoreValue++;
            currentPosition = 0;
            DestroySkydiver();
        } else if (collision.gameObject.name.Equals("Water"))
        { 
            Debug.Log("Sea");
            currentPosition = 0;
            DestroySkydiver();
        }
    }

    void DestroySkydiver()
    {
        GameObject parent = transform.gameObject;

        Destroy(parent);
    }

    //private bool TheParachuteMustBeVisible(bool visible)
    //{
    //    return gameObject.GetComponent<SpriteRenderer>().enabled = visible;
    //}
}
