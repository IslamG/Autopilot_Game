using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    [SerializeField]
    MouseIndicator mouse;
    Camera viewCamera;
    GameObject selectedObj;

    private void Start()
    {
        viewCamera = Camera.main;

        //crosshairAnimator = crosshair.GetComponent<Animator>();
    }

    private bool isHeld;

    //Called when mosue clicked
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse down");
            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5))
            {
                Debug.Log("Ray Hit");
                GameObject selection = hit.transform.gameObject;
                if (selection.GetComponent<Rigidbody>() != null && 
                    !selection.GetComponent<Rigidbody>().isKinematic)
                {
                    selectedObj = selection;
                    Debug.Log("RigidBody Found");
                    //selection.transform.position = gameObject.transform.position;
                    
                    isHeld = true;
                }
            }
        }
        if (isHeld)
        {
            selectedObj.transform.position = gameObject.transform.position;
            foreach(Collider col in selectedObj.GetComponents<Collider>())
            {
                col.enabled = false;
            }
        }
        if (Input.GetMouseButton(1))
        {
            selectedObj.transform.position = gameObject.transform.position;
            foreach (Collider col in selectedObj.GetComponents<Collider>())
            {
                col.enabled = true;

            }
            isHeld = false;

        }
        
    }

    //Called when mouse released
    private void OnMouseUp()
    {
        
    }
}
