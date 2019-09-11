using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip hitWater;
    public AudioClip commingDown;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        
        
    }

    public void soundWhwnParachutistHitWater()
    {
        audioSource.clip = hitWater;
        audioSource.Play();
    }

    public void SoundWhenParachutistCommingDown()
    {
        audioSource.clip = commingDown;
        audioSource.Play();
    }
}
