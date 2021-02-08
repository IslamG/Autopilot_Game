using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingMenu : MonoBehaviour
{
    public static SettingMenu instance; 

    private const string VOLUME = "Volume";
    private const string RESOLUTION = "Resolution";
    private const string GRAPHICS = "Graphics";
    private const string FULL_SCREEN = "Full_Screen";

    [SerializeField]
     AudioMixer audioMixer;
    [SerializeField]
     Dropdown resolutionDropdown;
    [SerializeField]
    private Slider volume;
    [SerializeField]
    Toggle fullScreen;
    [SerializeField]
    Dropdown resolution;
    [SerializeField]
    TMP_Dropdown quality;
    [SerializeField]
    Toggle checkBox;

    Resolution[] resolutions;
    int resolutionIndex, qualityIndex;
    bool isFullScreen, created=false;
    
    public bool Initialized { get; set; }
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Init()
    {
        if (!Initialized)
        {
            //Get current screen resolutions available
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            int currentResolutionIndex = 0;
            //Add to drop down option
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
            Initialized = true;
        }
        

    }
    //tbd change graphics of menu;
    private void Start()
    {

        //tbd load from player prefs if available
        if (PlayerPrefs.HasKey(VOLUME))
        {
            volume.value = PlayerPrefs.GetFloat(VOLUME);
        }
        if (PlayerPrefs.HasKey(GRAPHICS))
        {
            qualityIndex = PlayerPrefs.GetInt(GRAPHICS);
        }
        if (PlayerPrefs.HasKey(RESOLUTION))
        {
            resolutionIndex = PlayerPrefs.GetInt(RESOLUTION);
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
    }

    //Resolution drop down changed
    public  void SetResolution (int resolutionIndex)
    {
        //Get the value at selected index
        //and set screen resolutino to it
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        //resolutionDropdown.value = resolutions[resolutionIndex];
        resolutionDropdown.RefreshShownValue();
        //Set player prefs with changed information and save
        PlayerPrefs.SetInt(RESOLUTION, resolutionIndex);
        PlayerPrefs.Save();     
    }

    //Volume slider changed
    public  void SetVolume (float volume)
    {
        //Change main mixer to respond to volume change
       // Debug.Log("m " + staticMixer.name);

        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20 );
        //audioMixer.SetFloat("uiVolume", volume);
        //audioMixer.SetFloat("menuVolume", volume);
        //audioMixer.SetFloat("musiceVolume", volume);
        //audioMixer.SetFloat("enviromentVolume", volume);
        //audioMixer.SetFloat("playerVolume", volume);
        //audioMixer.SetFloat("effectsVolume", volume);
        //audioMixer.SetFloat("gameVolume", volume);
        //audioMixer.SetFloat("elevatorVolume", volume);
        //Save changes to player prefs
        PlayerPrefs.SetFloat(VOLUME, volume);
        PlayerPrefs.Save();
    }

    //Quality dropdown changed
    public  void SetQuality (int qualityIndex)
    {
        //Change quality based on index value
        QualitySettings.SetQualityLevel(qualityIndex);
        //Save changes to player prefs
        PlayerPrefs.SetInt(GRAPHICS, qualityIndex);
        PlayerPrefs.Save();
    }

    //Fullscren checkbox value changed
    public  void SetFullScreen (bool isFullScreen)
    {
        //Set fullscreen value based on checkbox
        Screen.fullScreen = isFullScreen;
        //Save changes to player prefs as integers
        if (isFullScreen)
        {
            //true =1
            PlayerPrefs.SetInt(FULL_SCREEN, 1);
            checkBox.isOn = true;
        }
        else
        {
            //false=0
            PlayerPrefs.SetInt(FULL_SCREEN, 0);
            checkBox.isOn = false;
        }
        PlayerPrefs.Save();
    }
}
