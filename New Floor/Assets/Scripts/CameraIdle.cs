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

    private void Start()
    {
        anim = transform.Find("IdleCamera").GetComponent<Animator>();
        mainCam = Camera.main;
        idleCam = transform.Find("IdleCamera").GetComponent<Camera>();
        //Debug.Log("I am "+idleCam.tag+" "+ anim.name);
    }
    void Update()
    {
        timeOutTimer += Time.deltaTime;
        if (Input.GetAxis("Mouse X") !=0 || Input.GetAxis("Mouse Y") != 0)
        {
            //Mouse moved, reset timer
            timeOutTimer = 0.0f;
            //Time.timeScale = 1f;
            //Debug.Log("Active");
            anim.SetBool("isActive", true);
            mainCam.enabled = true;
            idleCam.enabled = false;
        }

        if (timeOutTimer > timeOut)
        {
            //Mouse inactivity period has occured
            //Debug.Log("inactive");
            //Time.timeScale = 0f;
            anim.SetBool("isActive", false);
            mainCam.enabled = false;
            idleCam.enabled = true;


        }
    }
}