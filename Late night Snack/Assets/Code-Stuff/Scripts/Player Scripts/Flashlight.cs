using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool flashlightEnabled;
    public GameObject lightSource;
    public AudioSource clickSound;

    private bool failSafe = false;
    //public GameObject flashLight;
    //public GameObject lightObj;

    //public float maxEnergy;
    //private float currentEnergy;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(flashlightEnabled == false && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(true);
                clickSound.Play();
                flashlightEnabled = true;
                StartCoroutine(FailSafe());
            }
            else if (flashlightEnabled == true && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(false);
                clickSound.Play();
                flashlightEnabled = false;
                StartCoroutine(FailSafe());
            }
        }

    }

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }
}
