using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkInWaterController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> sharkPositions = new List<GameObject>();

    GameManager gameManager;

    private int random;
    private int randomMin = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateOrDeactivateSharkInWater());
    }

    IEnumerator ActivateOrDeactivateSharkInWater()
    {
        yield return new WaitForSeconds(5);

        while (true)
        {
            random = Random.Range(randomMin, sharkPositions.Count);

            yield return new WaitForSeconds(1);
            ShowShark(random);

            yield return new WaitForSeconds(1);
            HideShark(random);
        }
    }

    void ShowShark(int rand)
    {
        sharkPositions[rand].SetActive(true);
    }

    void HideShark(int rand)
    {
        sharkPositions[rand].SetActive(false);
    }
}
