using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPrefs : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;
    [SerializeField]
    SettingMenu settings;
    //Player prefs output, serialization
    //each corresponds to value
    /*
        [SerializeField]
        private Slider volume;
        [SerializeField]
        Toggle fullScreen;
        [SerializeField]
        Dropdown resolution;
        [SerializeField]
        TMP_Dropdown quality;
    */
    /* private void Start()
     {
         Debug.Log("Vol: "+volume.value);
         Debug.Log("Toggle: " + fullScreen.isOn);
         Debug.Log(quality.value);
         Debug.Log(resolution.value);
         volume.onValueChanged.AddListener(RegisterValue);
         fullScreen.onValueChanged.AddListener(RegisterValue);
         resolution.onValueChanged.AddListener(RegisterValue);
         quality.onValueChanged.AddListener(RegisterValue);
     }
     public void RegisterValue(float value)
     {
         Debug.Log("Volume " + value);
     }
     public void RegisterValue(bool value)
     {
         Debug.Log("Toggle " + value);
     }
     public void RegisterValue(int value)
     {
         Debug.Log("dropDown " + value);
     }*/

    private const string VOLUME = "Volume";
    private const string RESOLUTION = "Resolution";
    private const string GRAPHICS = "Graphics";
    private const string FULL_SCREEN = "Full_Screen";

    //private SaveData data;

    //public AudioMixer audioMixer;
    //public Dropdown resolutionDropdown;

    //Resolution[] resolutions;

    private void Start()
    {
        //tbd load from player prefs if available
        settings.Init();
        if (PlayerPrefs.HasKey(VOLUME))
        {
            SetVolume();
        }
        if (PlayerPrefs.HasKey(GRAPHICS))
        {
            SetQuality();
        }
        if (PlayerPrefs.HasKey(RESOLUTION))
        {
            SetResolution();
        }
        if (PlayerPrefs.HasKey(FULL_SCREEN))
        {
            SetFullScreen();
        }
        settings.Initialized = true;
    }

    //Resolution drop down changed
    private void SetResolution()
    {
        //Get the value at selected index
        //and set screen resolutino to it
        settings.SetResolution(PlayerPrefs.GetInt(RESOLUTION));
    }

    //Volume slider changed
    private  void SetVolume()
    {
        //Change main mixer to respond to volume change
        settings.SetVolume(PlayerPrefs.GetFloat(VOLUME));
        Debug.Log("voluming "+ PlayerPrefs.GetFloat(VOLUME));
    }

    //Quality dropdown changed
    private void SetQuality()
    {
        //Change quality based on index value
        settings.SetQuality(PlayerPrefs.GetInt(GRAPHICS));
        
    }

    //Fullscren checkbox value changed
    private void SetFullScreen()
    {
        //Set fullscreen value based on checkbox
        if (PlayerPrefs.GetInt(FULL_SCREEN) == 0)
        {
            settings.SetFullScreen(false);
        }
        else
        {
            settings.SetFullScreen(true);
        }
    }
}
