using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    private GameObject player;
    private static bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        //tbd when in vecinity of chair display message indicating sit
        Debug.Log("On");
        //Only if it's the character in vecinity
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            if (GetComponent<Rigidbody>() != null)
            {
                //Remove any force so chair doens't slide away
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
            }
        }
     }
    private void OnTriggerExit(Collider other)
    {
        //tbd remove message and disallow sitting
        Debug.Log("Off");
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    //Return if character is in range to sit
    public bool CanSit()
    {
        return inRange;
    }
}
