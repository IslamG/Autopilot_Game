using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    //HUD task text header animation end
    //Hide text box
    [SerializeField]
    GameObject textDisplay;
    public void DisableTextBox()
    {
        textDisplay.SetActive(false);
    }

    //Tutorial basic intro animation switch off
    //Turn on normal HUD
    [SerializeField]
    Canvas introCanvas, hudCanvas;
    public void SwitchTutorialBasic()
    {
        hudCanvas.gameObject.SetActive(true);
        introCanvas.gameObject.SetActive(false);
    }
}
