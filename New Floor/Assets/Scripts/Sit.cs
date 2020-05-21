using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sit : MonoBehaviour
{
    [SerializeField]
    private TMP_Text helperText;
    private GameObject player;
    private static bool inRange = false;
    private string sitText, standText;

    private void Start()
    {
        sitText = "Press J to sit";
        standText = "Press K to stand";
    }
    private void OnTriggerEnter(Collider other)
    {
        //Only if it's the character in vecinity
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            helperText.text = sitText;
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
            helperText.text = "";
        }
    }
    //Return if character is in range to sit
    public bool CanSit()
    {
        return inRange;
    }
}
