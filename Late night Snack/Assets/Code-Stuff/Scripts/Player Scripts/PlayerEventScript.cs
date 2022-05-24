using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Currently gonna be unused
/// </summary>

public class PlayerEventScript : MonoBehaviour
{
    public Scene currentScene = SceneManager.GetActiveScene();
    public TMP_Text startText;

    private float timeWhenDisapeear;

    // Start is called before the first frame update
    void Awake()
    {
        string sceneName = currentScene.name;

        if(sceneName == "Lägenheten")
        {
            ShowText(2f);
        }
    }

    // Update is called once per frame
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}


