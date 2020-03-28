using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private bool machineOn = false;

    public void OnMouseDown()
    {
        machineOn = !machineOn;
        if (machineOn)
        {
            transform.Translate(0, -0.001f, 0, Space.Self);
            Debug.Log("on");
        }
        else
        {
            transform.Translate(0, +0.001f, 0, Space.Self);
            Debug.Log("off");
        }
    }
}
