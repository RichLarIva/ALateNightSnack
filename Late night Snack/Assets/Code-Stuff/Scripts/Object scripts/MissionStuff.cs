using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionStuff : MonoBehaviour
{
    public TMP_Text missionText;

    private void OnTriggerEnter(Collider other)
    {
        missionText.enabled = true;
    }
}
