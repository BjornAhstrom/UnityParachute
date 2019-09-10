using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkfinController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> positions = new List<GameObject>();
    [SerializeField]
    GameManager gameManager;

    private int random;
    private int randomMin = 0;

    private void Start()
    {
        StartCoroutine(ActivateSharkfin());
    }

    IEnumerator ActivateSharkfin()
    {
        yield return new WaitForSeconds(gameManager.startWaitSecondsForSharkfinToShowUpOrHide);
        
        while (true)
        {
            random = Random.Range(randomMin, positions.Count);

            yield return new WaitForSeconds(gameManager.waitSecondsForSharkfinToShowUpOrHide);
            ShowRandomSharkfinInWater(random);

            yield return new WaitForSeconds(gameManager.waitSecondsForSharkfinToShowUpOrHide);
            HideRandomSharkfinInWater(random);
            //StartCoroutine(DeactivateSharkfin(rand));
        }
    }


    void ShowRandomSharkfinInWater(int rand)
    {
        positions[rand].SetActive(true);
    }

    void HideRandomSharkfinInWater(int rand)
    {
        positions[rand].SetActive(false);
    }
}
