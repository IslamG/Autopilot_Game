using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceConstraint : MonoBehaviour
{
    [SerializeField]
    private bool xConstrain, yConstrain, zConstrain;
    [SerializeField]
    private float minX, maxX, minY, maxY, minZ, maxZ;
    private Vector3 currentPosition;
    void Update()
    {
        // get the position to a variable
        currentPosition = transform.localPosition;
        if (xConstrain) { 
        // modify the variable to keep x within minX to maxX
        currentPosition.x =
           Mathf.Clamp(currentPosition.x, minX, maxX);
        }
        if (yConstrain)
        {
            currentPosition.y =
               Mathf.Clamp(currentPosition.y, minY, maxY);
        }
        if (zConstrain)
        {
            currentPosition.z =
               Mathf.Clamp(currentPosition.z, minZ, maxZ);
        }
        // and now set the transform position to our modified vector
        transform.localPosition = currentPosition;
    }
}
