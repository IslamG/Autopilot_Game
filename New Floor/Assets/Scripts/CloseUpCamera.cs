using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpCamera : MonoBehaviour
{
    [SerializeField]
    GameObject[] focusObjects;
    [SerializeField]
    private float reach, space;

    bool isFocused = false;
    private Camera closeUpCam;
    private Transform focusPoint;
    private Vector3 originalPos;
    private MouseIndicator mouse;
    private void Start()
    {
        closeUpCam = this.gameObject.GetComponent<Camera>();
        mouse = gameObject.GetComponent<MouseIndicator>();
    }
    private void Update()
    {
        Ray ray = closeUpCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reach))
        {
            //Check if we're mousing over an object we can focus
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            foreach(GameObject obj in focusObjects)
            {
                if (hit.transform.gameObject == obj && Input.GetMouseButton(0) && !isFocused)
                {
                    focusPoint = hit.transform;
                    originalPos= closeUpCam.transform.position;
                    FocusCamera();
                    isFocused = true;
                }
            }            
        }
        //Unfocus camera on right click
        if (isFocused && Input.GetMouseButton(1))
        {
            UnfocusCamera();
            isFocused = false;
        }
    }
    //tbd possibly switch out between a "close up camera" and main
    private void FocusCamera()
    {
        float xDiff, zDiff, spaceX, spaceZ;
        //Find where the camera is facing the object from
        xDiff = focusPoint.position.x - closeUpCam.transform.position.x;
        zDiff = focusPoint.position.z - closeUpCam.transform.position.z;

        //newPos.x = focusPoint.position.x+0.1f;
        //newPos.y = focusPoint.position.y; 
        //newPos.z= focusPoint.position.z +0.6f;
        //closeUpCam.transform.position = newPos;
        //spaceX = xDiff-space;
        //spaceZ = zDiff-space;

        //Move the camera relevent to its position to the object's position
        if (xDiff <= 0 && zDiff <= 0)
        {
            xDiff= focusPoint.position.x + space;
            zDiff= focusPoint.position.z + space;
        }
        else if (xDiff <= 0 && zDiff >= 0)
        {
            xDiff = focusPoint.position.x + space;
            zDiff = focusPoint.position.z - space;
        }
        else if (xDiff >= 0 && zDiff <= 0)
        {
            xDiff = focusPoint.position.x - space;
            zDiff = focusPoint.position.z + space;
        }
        else if (xDiff >= 0 && zDiff >= 0)
        {
            xDiff = focusPoint.position.x - space;
            zDiff = focusPoint.position.z - space;
        }
        //Set the new close position
        closeUpCam.transform.position = new Vector3(xDiff, focusPoint.position.y+0.05f, zDiff);
        mouse.Focus();
    }
    //return to position before focusing
    private void UnfocusCamera()
    {
        closeUpCam.transform.position = originalPos;
        mouse.Unfocus();
    }
}
