using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysPuzzle : Glow
{
    public GameObject usb, laptop, mop, coffeeMachine;
    private static bool preReq = false;
    private static GameObject nextObj;

    private void Start()
    {
        nextObj = usb;
    }
    
    private void TechnoRoute()
    {
        glow(nextObj);
        preReq = !preReq;
        nextObj = laptop;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Here");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100)) // or whatever range, if applicable
            {
                if (hit.transform.gameObject == nextObj)
                {
                    // You clicked the same object twice
                    Debug.Log("hit");
                    TechnoRoute();
                }
                else
                {
                    // lastHit = hit.transform.gameObject;
                    Debug.Log("not hit");
                }
            }
            else
            {
                Debug.Log("out of range");
                // You didn't click on anything.
                // Either out of range or empty skybox behind mouse cursor
            }
        }
    }
}
