using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    [SerializeField]
    MouseIndicator mouse;

    private bool isHeld;

    //Called when mosue clicked
    private void OnMouseDown()
    {
        //Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, reach))
        //{}
    }

    //Called when mouse released
    private void OnMouseUp()
    {
        
    }
}
