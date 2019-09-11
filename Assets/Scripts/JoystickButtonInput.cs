using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickButtonInput : MonoBehaviour
{
    
    //public enum Button
    //{
    //    left,
    //    right
    //}

    //public Button button;
    //public bool leftBtn;

    public delegate void ButtonPressed();
    public static event ButtonPressed LeftButton;
    public static event ButtonPressed RightButton;
    public static event ButtonPressed GameA;
    public static event ButtonPressed TimeMenu;

#if (UNITY_EDITOR)
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (LeftButton != null && hit.collider != null && hit.collider.tag == "LeftButton")
            {
                Debug.Log("Left press");
                LeftButton();
                //boatController.OnLeftButtonPressed();
            }
            else if (RightButton != null && hit.collider != null && hit.collider.tag == "RightButton")
            {
                Debug.Log("Right press");
                RightButton();
                //boatController.OnRightButtonPressed();
            }
            else if (GameA != null && hit.collider != null && hit.collider.tag == "GameAButton")
            {
                Debug.Log("Game A");
                GameA();
            }
            else if (TimeMenu != null && hit.collider != null && hit.collider.tag == "TimeMenuButton")
            {
                Debug.Log("Time Menu");
                TimeMenu();
            }
        }
    }


#elif (UNITY_IOS || UNITY_ANDROID)
    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if (LeftButton != null && hit.collider != null && hit.collider.tag == "LeftButton")
                {
                    Debug.Log("Left press");
                    LeftButton();
                    //boatController.OnLeftButtonPressed();
                }
                else if (RightButton != null && hit.collider != null && hit.collider.tag == "RightButton")
                {
                    Debug.Log("Right press");
                    RightButton();
                    //boatController.OnRightButtonPressed();
                }
                else if (GameA != null && hit.collider != null && hit.collider.tag == "GameAButton")
                {
                    Debug.Log("Game A");
                    GameA();
                }
                else if (TimeMenu != null && hit.collider != null && hit.collider.tag == "TimeMenuButton")
                {
                    Debug.Log("Time Menu");
                    TimeMenu();
                }
            }
        }
    }
#endif
    //public BoatController boatController;

    //private void OnMouseDown()
    //{
    //    if (LeftButton != null && button == Button.left)
    //    {
    //        Debug.Log("Left press");
    //        LeftButton();
    //        //boatController.OnLeftButtonPressed();
    //    }
    //    else if (RightButton != null && button == Button.right)
    //    {
    //        Debug.Log("Right press");
    //        RightButton();
    //        //boatController.OnRightButtonPressed();
    //    }
    //}
}
