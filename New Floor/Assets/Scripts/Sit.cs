using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    private GameObject player;
    private static bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("On");
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            if (GetComponent<Rigidbody>() != null)
            {
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
            }
        }
     }
    private void OnTriggerExit(Collider other)
    {

        Debug.Log("Off");
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    public bool CanSit()
    {
        return inRange;
    }
}
