using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStarter : MonoBehaviour
{
    public bool collectedFood = false;
    public bool collectedSecret = false;
    public GameObject collectFoodText;
    public int seconds;

    private void OnTriggerEnter(Collider other)
    {
        if (collectedFood == false)
        {
            if (other.gameObject.tag == "Player")
            {
                collectFoodText.SetActive(true);
                collectedFood = true;
                StartCoroutine("WaitForSec");
            }
        }
    }


    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(collectFoodText);
    }
}
