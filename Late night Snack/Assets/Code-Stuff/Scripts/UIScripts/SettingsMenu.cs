using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;
    public Slider audioSlider;

    [Header("Dropdowns")]
    public TMP_Dropdown resDropDown;
    public TMP_Dropdown graphDropDown;

    public Toggle fullscreenToggle;

    Resolution[] resolutions;

    private bool isFullscreen = false;
    private int screenInt;

    const string prefName = "qualityValue";
    const string resName = "resolutionOption";

    private void Awake()
    {
        screenInt = PlayerPrefs.GetInt("toggleState");

        if(screenInt == 1)
        {
            isFullscreen = true;
            fullscreenToggle.isOn = true;
        }
        else if(screenInt == 0)
        {
            isFullscreen = false;
            fullscreenToggle.isOn = false;
        }

        
    }

    private void Start()
    {
        audioSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));

        graphDropDown.value = PlayerPrefs.GetInt(prefName, 3);

        resolutions = Screen.resolutions;
        resDropDown.ClearOptions();

        resDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resDropDown.value);
            PlayerPrefs.Save();
        }));
        graphDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, graphDropDown.value);
            PlayerPrefs.Save();
        }));

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resDropDown.AddOptions(options);
        resDropDown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resDropDown.RefreshShownValue();

    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if (isFullscreen == false)
            PlayerPrefs.SetInt("toggleState", 0);
        else
            PlayerPrefs.SetInt("toggleState", 1);
    }
}
