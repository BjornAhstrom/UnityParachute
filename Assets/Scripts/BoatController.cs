using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    //public List<GameObject> boatPositions = new List<GameObject>();
    //public SkydiverController skydiver;

    public static int currentBoatPosition = 1;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateBoatPosition();
        //MoveBoat(currentBoatPosition);
        //boatPositions[1].SetActive(true);
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
            //MoveBoat(currentBoatPosition);
            UpdateBoatPosition();
        }
    }

    public void OnRightButtonPressed()
    {
        if (currentBoatPosition < positions.Count - 1)
        {
            currentBoatPosition++;
           // MoveBoat(currentBoatPosition);
            UpdateBoatPosition();
        }
    }

    //void MoveBoat(int pos)
    //{
    //    if (pos == 0)
    //    {
    //        boatPositions[0].SetActive(true);
    //    }
    //    else
    //    {
    //        boatPositions[0].SetActive(false);
    //    }
    //    if (pos == 1)
    //    {
    //        boatPositions[1].SetActive(true);
    //    }
    //    else
    //    {
    //        boatPositions[1].SetActive(false);
    //    }
    //    if (pos == 2)
    //    {
    //        boatPositions[2].SetActive(true);
    //    }
    //    else
    //    {
    //        boatPositions[2].SetActive(false);
    //    }
    //}

    private void UpdateBoatPosition()
    {
        transform.position = positions[currentBoatPosition].position;
    }
}
