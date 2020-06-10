using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ClockFace : MonoBehaviour
{
    [SerializeField]
    Canvas hud;
    [SerializeField]
    GameObject minuteArm, hourArm;
    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    AheadClock aheadClock;
    [SerializeField]
    DelayedClock delayedClock;

    Camera self, main;
    bool inClock = false;

    private void Start()
    {
         self = GetComponentInChildren<Camera>();
         main = Camera.main;
    }
    public void SetNewTime(float minutes, float hours)
    {
        Vector3 newAngle = minuteArm.transform.localEulerAngles;
        newAngle.z -= minutes;
        minuteArm.transform.localEulerAngles = newAngle;

        newAngle =hourArm.transform.localEulerAngles;
        newAngle.z -= hours;
        hourArm.transform.localEulerAngles = newAngle;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!inClock)
        {
            MouseOverClock();
        }
        if (Input.GetMouseButtonDown(1)&& inClock)
        {
            ExitGameView();
        }
        if (Input.GetMouseButtonDown(0) && inClock)
        {
            Debug.Log("Try");
            MouseOverArm();
        }
    }

    private void EnterGameView()
    {
        inClock = true;
        self.enabled = true;
        main.enabled = false;
        minuteArm.GetComponent<BoxCollider>().enabled = true;
        hourArm.GetComponent<BoxCollider>().enabled = true;

        fpc.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        hud.enabled = false;
    }
    private void ExitGameView()
    {
        inClock = false;
        main.enabled = true;
        self.enabled = false;
        minuteArm.GetComponent<BoxCollider>().enabled = false;
        hourArm.GetComponent<BoxCollider>().enabled = false;

        fpc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        hud.enabled = true;
    }
    private void MouseOverClock()
    {
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            //Debug.DrawRay(transform.position, transform.forward, Color.green);
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj==this.gameObject)//.name.Equals("Clock"))
            {
                EnterGameView();
            }
        }
    }
    private void MouseOverArm()
    {
        Ray ray = self.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            Debug.Log("Shit");
            //Debug.DrawRay(transform.position, transform.forward, Color.green);
            GameObject hitObj = hit.collider.gameObject;
            Transform[] children = gameObject.GetComponentsInChildren<Transform>();
            foreach(Transform child in children)
            {
                if (hitObj==child.gameObject && hitObj!=self.gameObject 
                    && hitObj != gameObject)
                {
                    Vector3 newAngle = hitObj.transform.localEulerAngles;
                    newAngle.z -= 30;
                    hitObj.transform.localEulerAngles = newAngle;

                    if (gameObject.GetComponent<AheadClock>() != null)
                    {
                        delayedClock.Delay();
                    }
                    else
                    {
                        aheadClock.Forward();
                    }
                    break;
                }
            }
            
        }
    }
}
