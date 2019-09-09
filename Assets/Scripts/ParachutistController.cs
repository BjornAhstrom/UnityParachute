﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutistController : MonoBehaviour
{
    [SerializeField]
    List<Transform> leftPositions = new List<Transform>();
    [SerializeField]
    List<Transform> middlePositions = new List<Transform>();
    [SerializeField]
    List<Transform> rightPositions = new List<Transform>();

    [HideInInspector]
    public ParachutistSpawnerController parachutistSpawner;

    private int currentPosition = 0;
    private float nextUpdate;
    private int random;
    private int randomRangeMin = 1;
    private int randomRangeMax = 4;

    [SerializeField]
    private float timeSpeed = 1.0f;

    private void Start()
    {
        nextUpdate = Time.time;
        
        random = Random.Range(randomRangeMin, randomRangeMax);
    }

    private void Update()
    {
        if (Time.time > nextUpdate + timeSpeed)
        {
            SetRandomOnParchutistPositions(random);

            nextUpdate = Time.time;
            
        }
    }

    private void MoveSkydiverToNextPosition(List<Transform> pos)
    {
        currentPosition++;

        if (currentPosition >= pos.Count)
        {
            DestroySkydiver();
        }
        else
        {
            transform.position = pos[currentPosition].position;
        }
}

    void SetRandomOnParchutistPositions(int rand)
    {
        switch (rand)
        {
            case 1:
                MoveSkydiverToNextPosition(leftPositions);
                break;
            case 2:
                MoveSkydiverToNextPosition(middlePositions);
                break;
            case 3:
                MoveSkydiverToNextPosition(rightPositions);
                break;
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
        GameObject parachutist = transform.gameObject;

        Destroy(parachutist);
    }
}