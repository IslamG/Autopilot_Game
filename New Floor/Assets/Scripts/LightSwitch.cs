using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private bool switchOn = true;
    public Light[] lights;

    public void OnMouseDown()
    {
        //On button clicked reverse state
        switchOn = !switchOn;
        if (switchOn)
        {
            //When switch on, turn on lights associated with button
            foreach(Light bulb in lights)
            {
                bulb.enabled = true;
            }
            //Flip switch
            transform.Rotate(0, 0, +10f, Space.Self);
        }
        //Turn off bulb
        else
        {
            foreach (Light bulb in lights)
            {
                bulb.enabled = false;
            }
            transform.Rotate(0, 0, -10f, Space.Self);
        }
    }
}
