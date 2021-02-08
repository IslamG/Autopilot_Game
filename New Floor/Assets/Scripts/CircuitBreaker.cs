using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreaker : MonoBehaviour
{
    [SerializeField]
    PourLiquid[] dispensers;
    [SerializeField]
    RenderTexture[] displayScreens;
    [SerializeField]
    ElevatorDoor[] elevatorButtons;
    [SerializeField]
    InteractableScreen[] interactableScreens;
    [SerializeField]
    GameObject[] glowingMats;
    [SerializeField]
    Material replacement, darkSky;
    [SerializeField]
    GameObject[] secutiryCams;

    Light[] lights;
    TurnOnFan[] fans;
    TurnOnScreen[] screens;
    LightSwitch[] switches;

    private void OnMouseDown()
    {
        lights = GameObject.FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            light.gameObject.SetActive(false);
        }
        fans = GameObject.FindObjectsOfType<TurnOnFan>();
        foreach (TurnOnFan fan in fans)
        {
            fan.enabled = false;
            fan.IsEnabled = false;
        }
        screens = GameObject.FindObjectsOfType<TurnOnScreen>();
        foreach (TurnOnScreen screen in screens)
        {
            screen.enabled = false;
            screen.IsEnabled = false;
        }
        foreach (InteractableScreen screen in interactableScreens)
        {
            screen.enabled = false;
        }
        switches = GameObject.FindObjectsOfType<LightSwitch>();
        foreach (LightSwitch buttonSwitch in switches)
        {
            buttonSwitch.enabled = false;
        }
        foreach (RenderTexture display in displayScreens)
        {
            display.Release();
        }
        foreach (PourLiquid liquid in dispensers)
        {
            liquid.enabled = false;
            liquid.IsEnabled = false;
        }
        foreach (ElevatorDoor elevatorButton in elevatorButtons)
        {
            elevatorButton.enabled = false;
            elevatorButton.IsEnabled = false;
        }
        foreach (GameObject mat in glowingMats)
        {
            mat.GetComponent<MeshRenderer>().material=replacement;
        }
        foreach (GameObject cam in secutiryCams)
        {
            cam.SetActive(false);
        }
        //RenderSettings.skybox.SetFloat("_Exposure",2f);
        RenderSettings.ambientIntensity = 0.25f;
        RenderSettings.skybox = darkSky;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
