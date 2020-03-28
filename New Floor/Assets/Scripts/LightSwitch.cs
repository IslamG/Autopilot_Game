using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private bool switchOn = true;
    //public Light bulb;
    public Light[] lights;

    public void OnMouseDown()
    {
        switchOn = !switchOn;
        if (switchOn)
        {
            foreach(Light bulb in lights)
            {
                bulb.enabled = true;
            }  
            transform.Rotate(0, 0, +10f, Space.Self);
        }
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
