using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraIdle : MonoBehaviour
{
    float timeOut = 5.0f; // Time Out Setting in Secounds
    private float timeOutTimer = 0.0f;
    private Animator anim;
    private Camera mainCam, idleCam;

    //Initialize variables
    private void Start()
    {
        anim = transform.Find("IdleCamera").GetComponent<Animator>();
        mainCam = Camera.main;
        idleCam = transform.Find("IdleCamera").GetComponent<Camera>();
    }
    void Update()
    {
        //Increase time without input
        timeOutTimer += Time.deltaTime;

        //Mouse moved, reset timer
        if (Input.GetAxis("Mouse X") !=0 || Input.GetAxis("Mouse Y") != 0)
        {
            timeOutTimer = 0.0f;
            anim.SetBool("isActive", true);
            mainCam.enabled = true;
            idleCam.enabled = false;
        }
        //Mouse inactivity period has occured
        if (timeOutTimer > timeOut)
        {
            anim.SetBool("isActive", false);
            mainCam.enabled = false;
            idleCam.enabled = true;
        }
    }
}