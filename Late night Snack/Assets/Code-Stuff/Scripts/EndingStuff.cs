using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStuff : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject worker;
    public EndingStarter endingOne;
    public int seconds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (endingOne.collectedFood == true)
            {
                triggerText.SetActive(true);
                StartCoroutine("WaitForSec");
                Destroy(worker);
            }
        }
    }


    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(triggerText);
    }
}
