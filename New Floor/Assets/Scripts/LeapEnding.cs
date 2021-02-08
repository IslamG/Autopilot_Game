using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapEnding : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Play ending");

        }
    }
}
