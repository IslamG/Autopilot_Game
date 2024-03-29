﻿using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

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
            //Debug.DrawRay(transform.position, transform.forward, Color.green);
            foreach (GameObject obj in focusObjects)
            {
                //If we'er over an object we can focus and mouse is clicked
                if (hit.transform.gameObject == obj && Input.GetMouseButton(0) && !isFocused)
                {
                    //Move camera to focus position
                    focusPoint = hit.transform;
                    originalPos = closeUpCam.transform.position;
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
        //Disable movement control if is active
        if (gameObject.name.Equals("FirstPersonCharacter"))
        {
            gameObject.GetComponentInParent<FirstPersonController>().CanMove = false;
        }
        float xDiff = 0, zDiff = 0;
        //Find where the camera is facing the object from
        Vector3 target = focusPoint.position,
            point = closeUpCam.transform.position;
        float angle = GetAngle(point, target);
        //Debug.Log("Angle: " + angle);
        //Debug.Log("Quarter: "+GetQuarter(target, point));
        //Move the camera relevent to its position to the object's position
        switch (GetQuarter(target, point))
        {
            //focus object is in first quareter
            case 1:
                {//x=+, z=+
                    //Calculate angle to decide where to move camera to
                    if (angle > 45)
                    {
                        xDiff = target.x;
                        zDiff = target.z + space;
                    }
                    else
                    {
                        xDiff = target.x + space;
                        zDiff = target.z;
                    }
                    break;
                }
            //focus object is in second quareter
            case 2:
                {//x=-, z=+
                    //Calculate angle to decide where to move camera to
                    if (angle > 115)
                    {
                        xDiff = target.x;
                        zDiff = target.z + space;
                    }
                    else
                    {
                        xDiff = target.x - space;
                        zDiff = target.z;
                    }
                    break;
                }
            //focus object is in third quareter
            case 3:
                {
                    //x= -, z=-
                    //Calculate angle to decide where to move camera to
                    if (angle > 225)
                    {
                        xDiff = target.x;
                        zDiff = target.z - space;
                    }
                    else
                    {
                        xDiff = target.x - space;
                        zDiff = target.z;
                    }
                    break;
                }
            //focus object is in fourth quareter
            case 4:
                {//x=+, z=+
                    //Calculate angle to decide where to move camera to
                    if (angle > 315)
                    {
                        xDiff = target.x;
                        zDiff = target.z - space;
                    }
                    else
                    {
                        xDiff = target.x + space;
                        zDiff = target.z;
                    }
                    break;
                }
        }
        //Set the new close position
        closeUpCam.transform.position = new Vector3(xDiff, target.y + 0.05f, zDiff);
        //closeUpCam.transform.LookAt(target);
        mouse.Focus();
    }
    //return to position before focusing
    private void UnfocusCamera()
    {
        //Reinable movement if available
        if (gameObject.name.Equals("FirstPersonCharacter"))
        {
            gameObject.GetComponentInParent<FirstPersonController>().CanMove = true;
        }
        closeUpCam.transform.position = originalPos;
        mouse.Unfocus();
    }
    //Calculate view angle between focus point and where camera is facing
    private float GetAngle(Vector3 target, Vector3 point)
    {
        float w = target.x - point.x;
        float h = target.z - point.z;

        float atan = Mathf.Atan(h / w) / Mathf.PI * 180;
        if (w < 0 || h < 0)
            atan += 180;
        if (w > 0 && h < 0)
            atan -= 180;
        if (atan < 0)
            atan += 360;

        return atan % 360;
    }
    //Calculae which quarter the camera is in
    //relative to the focus object clicked
    private int GetQuarter(Vector3 target, Vector3 point)
    {
        float xDiff = target.x - point.x;
        float zDiff = target.z - point.z;

        //1st quarter
        if (xDiff < 0 && zDiff < 0)
        {
            xDiff = focusPoint.position.x;  // + spaceX;
            zDiff = focusPoint.position.z + space;
            Debug.Log("In 1");
            return 1;
        }
        //2nd quarter
        else if (xDiff > 0 && zDiff < 0)
        {
            xDiff = focusPoint.position.x;// - spaceX;
            zDiff = focusPoint.position.z + space;
            Debug.Log("In 2");
            return 2;
        }
        //3rd quarter
        else if (xDiff > 0 && zDiff > 0)
        {
            xDiff = focusPoint.position.x;  // - spaceX;
            zDiff = focusPoint.position.z - space;
            Debug.Log("In 3");
            return 3;
        }
        //4th quarter
        else if (xDiff < 0 && zDiff > 0)
        {
            xDiff = focusPoint.position.x;// + spaceX;
            zDiff = focusPoint.position.z - space;
            Debug.Log("In 4");
            return 4;
        }
        return 5;
    }
}
