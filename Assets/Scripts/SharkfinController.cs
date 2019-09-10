using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkfinController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> sharkFinPositions = new List<GameObject>();

    [SerializeField]
    GameManager gameManager;

    private int random;
    private int randomMin = 0;

    [HideInInspector]
    public bool runSharkFin = true;

    private void Start()
    {
        StartCoroutine(ActivateAndDeactivateSharkfin());
    }

    IEnumerator ActivateAndDeactivateSharkfin()
    {
        while (runSharkFin)
        {
            yield return new WaitForSeconds(gameManager.startWaitSecondsForSharkFinToShowUpOrHide);

            random = Random.Range(randomMin, sharkFinPositions.Count);

            yield return new WaitForSeconds(gameManager.waitSecondsForSharkFinToShowUpOrHide);
            ShowRandomSharkFinInWater(random);

            yield return new WaitForSeconds(gameManager.waitSecondsForSharkFinToShowUpOrHide);
            HideRandomSharkFinInWater(random);
        }
    }

    void ShowRandomSharkFinInWater(int rand)
    {
        sharkFinPositions[rand].SetActive(true);
    }

    void HideRandomSharkFinInWater(int rand)
    {
        sharkFinPositions[rand].SetActive(false);
    }
}
