using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTeleport : MonoBehaviour
{
    public EndingStarter endingOne;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (endingOne.collectedFood == true && endingOne.collectedSecret == false)
            {
                SceneManager.LoadScene("EndingOne");
            }

            else if (endingOne.collectedSecret == true && endingOne.collectedFood == true)
                SceneManager.LoadScene("EndingTwo");
        }
    }
}
