using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScriptForText : MonoBehaviour
{
    public TMP_Text startText;

    private float timeWhenDisapeear;

    public float timeToAppear;

    // Start is called before the first frame update
    void Start()
    {
        ShowText(timeToAppear);
    }

    void Update()
    {
        if (startText.enabled && (Time.time >= timeWhenDisapeear))
            startText.enabled = false;
    }

    void ShowText(float timeToAppear)
    {
        startText.enabled = true;
        timeWhenDisapeear = Time.time + timeToAppear;
    }
}
