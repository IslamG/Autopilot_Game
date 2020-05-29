using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingMenu : MonoBehaviour
{
    private const string VOLUME = "Volume";
    private const string RESOLUTION = "Resolution";
    private const string GRAPHICS = "Graphics";
    private const string FULL_SCREEN = "Full_Screen";

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    
    private void Start()
    {
        resolutions= Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width +" x "+ resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width==Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        /*
        if (PlayerPrefs.HasKey(VOLUME))
        {
            volume = PlayerPrefs.GetFloat(VOLUME);
        }
        if (PlayerPrefs.HasKey(GRAPHICS))
        {
            qualityIndex = PlayerPrefs.GetInt(GRAPHICS);
        }
        if (PlayerPrefs.HasKey(RESOLUTION))
        {
            qualityIndex = PlayerPrefs.GetInt(RESOLUTION);
        }
        if (PlayerPrefs.HasKey(FULL_SCREEN))
        {
            if (PlayerPrefs.GetInt(FULL_SCREEN) == 0)
            {
                isFullScreen = false;
            }
            else
            {
                isFullScreen = true;
            }
        }
        */
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION, resolutionIndex);
        PlayerPrefs.Save();
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat(VOLUME, volume);
        PlayerPrefs.Save();

    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt(GRAPHICS, qualityIndex);
        PlayerPrefs.Save();
    }
    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
        {
            PlayerPrefs.SetInt(FULL_SCREEN, 1);
        }
        else
        {
            PlayerPrefs.SetInt(FULL_SCREEN, 0);
        }
        PlayerPrefs.Save();
    }
}
