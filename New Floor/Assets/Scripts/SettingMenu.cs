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
        //Get current screen resolutions available
        resolutions= Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        //Add to drop down option
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

        //tbd load from player prefs if available
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

    //Resolution drop down changed
    public void SetResolution (int resolutionIndex)
    {
        //Get the value at selected index
        //and set screen resolutino to it
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        //Set player prefs with changed information and save
        PlayerPrefs.SetInt(RESOLUTION, resolutionIndex);
        PlayerPrefs.Save();
    }

    //Volume slider changed
    public void SetVolume (float volume)
    {
        //Change main mixer to respond to volume change
        audioMixer.SetFloat("volume", volume);
        //Save changes to player prefs
        PlayerPrefs.SetFloat(VOLUME, volume);
        PlayerPrefs.Save();
    }

    //Quality dropdown changed
    public void SetQuality (int qualityIndex)
    {
        //Change quality based on index value
        QualitySettings.SetQualityLevel(qualityIndex);
        //Save changes to player prefs
        PlayerPrefs.SetInt(GRAPHICS, qualityIndex);
        PlayerPrefs.Save();
    }

    //Fullscren checkbox value changed
    public void SetFullScreen (bool isFullScreen)
    {
        //Set fullscreen value based on checkbox
        Screen.fullScreen = isFullScreen;
        //Save changes to player prefs as integers
        if (isFullScreen)
        {
            //true =1
            PlayerPrefs.SetInt(FULL_SCREEN, 1);
        }
        else
        {
            //false=0
            PlayerPrefs.SetInt(FULL_SCREEN, 0);
        }
        PlayerPrefs.Save();
    }
}
