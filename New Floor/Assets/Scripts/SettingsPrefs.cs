using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPrefs : MonoBehaviour
{
    //Player prefs output, serialization
    //each corresponds to value

    [SerializeField]
    private Slider volume;
    [SerializeField]
    Toggle fullScreen;
    [SerializeField]
    Dropdown resolution;
    [SerializeField]
    TMP_Dropdown quality;

    private void Start()
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
    }
}
