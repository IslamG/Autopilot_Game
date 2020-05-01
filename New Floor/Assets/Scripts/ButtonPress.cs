using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private bool machineOn = false;

    //Turn on and off based on click
    //Moving button to be pushed in or out
    public void OnMouseDown()
    {
        machineOn = !machineOn;
        if (machineOn)
        {
            transform.Translate(0, -0.001f, 0, Space.Self);
            //tbd add animation for machine running
        }
        else
        {
            transform.Translate(0, +0.001f, 0, Space.Self);
            //tbd stop machine running animation
        }
    }
}
