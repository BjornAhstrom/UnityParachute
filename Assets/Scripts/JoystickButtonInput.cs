using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickButtonInput : MonoBehaviour
{
    
    public enum Button
    {
        left,
        right
    }

    public Button button;
    //public bool leftBtn;

    public delegate void ButtonPressed();
    public static event ButtonPressed LeftButton;
    public static event ButtonPressed RightButton;

    //public BoatController boatController;

    private void OnMouseDown()
    {
        if (LeftButton != null && button == Button.left)
        {
            Debug.Log("Left press");
            LeftButton();
            //boatController.OnLeftButtonPressed();
        }
        else if (RightButton != null && button == Button.right)
        {
            Debug.Log("Right press");
            RightButton();
            //boatController.OnRightButtonPressed();
        }
    }
}
