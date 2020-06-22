using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private bool machineOn = false;

    //Turn on and off based on click
    //Moving button to be pushed in or out
    //Tbd add sound on click
    public void OnMouseDown()
    {
        machineOn = !machineOn;
        if (machineOn)
        {
            transform.Translate(0, 0, -0.01f, Space.Self);
            Debug.Log("Button In");
            //tbd add animation for machine running
        }
        else
        {
            transform.Translate(0, 0, +0.01f, Space.Self);
            Debug.Log("Button Out");
            //tbd stop machine running animation
        }
    }
}
