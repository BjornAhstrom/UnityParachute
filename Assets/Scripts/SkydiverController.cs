using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkydiverController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positions = new List<Transform>();

    public int currentPosition = 0;
    private float nextUpdate;
    public float timeSpeed = 1.0f;

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
            GameObject parent = transform.parent.gameObject;
        } else
        {
            transform.position = positions[currentPosition].position;
        }

        
    }

    //private bool TheParachuteMustBeVisible(bool visible)
    //{
    //    return gameObject.GetComponent<SpriteRenderer>().enabled = visible;
    //}
}
