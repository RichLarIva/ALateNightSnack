using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerHandler : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject worker;
    public EndingStarter endingOne;
    public int seconds;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerText.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }


    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(triggerText);
    }
}
