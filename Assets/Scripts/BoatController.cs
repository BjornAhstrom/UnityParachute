﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    //public SkydiverController skydiver;

    public static int currentBoatPosition = 1;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBoatPosition();
    }

    private void OnEnable()
    {
        JoystickButtonInput.LeftButton += OnLeftButtonPressed;
        JoystickButtonInput.RightButton += OnRightButtonPressed;
    }

    private void OnDisable()
    {
        JoystickButtonInput.LeftButton -= OnLeftButtonPressed;
        JoystickButtonInput.RightButton -= OnRightButtonPressed;
    }

    public void OnLeftButtonPressed()
    {
        if (currentBoatPosition > 0)
        {
            currentBoatPosition--;
            UpdateBoatPosition();
        }
    }

    public void OnRightButtonPressed()
    {
        if (currentBoatPosition < positions.Count - 1)
        {
            currentBoatPosition++;
            UpdateBoatPosition();
        }
    }

    private void UpdateBoatPosition()
    {
        transform.position = positions[currentBoatPosition].position;
    }
}
