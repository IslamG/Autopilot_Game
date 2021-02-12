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
    GameObject[] glowingMats, secutiryCams, machines, lvlScreens;
    [SerializeField]
    Material replacement, darkSky;
    [SerializeField]
    AudioSource[] soundMakers;

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
            fan.GetComponentInChildren<Animator>().enabled = false;
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
            mat.GetComponent<MeshRenderer>().material = replacement;
        }
        foreach (GameObject cam in secutiryCams)
        {
            cam.SetActive(false);
        }
        foreach (GameObject scrn in lvlScreens)
        {
            scrn.SetActive(false);
        }
        foreach (GameObject machine in machines)
        {
            machine.GetComponent<ButtonPress>().IsEnabled = false;
        }
        foreach (AudioSource source in soundMakers)
        {
            source.Stop();
        }
        //RenderSettings.skybox.SetFloat("_Exposure",2f);
        RenderSettings.ambientIntensity = 0.25f;
        RenderSettings.skybox = darkSky;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
