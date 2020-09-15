using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows non-kinmatic rigid body objects to be picked up and dropped.
/// </summary>
public class HoldObject : MonoBehaviour
{
    [SerializeField]
    MouseIndicator mouse;
    Camera viewCamera;
    GameObject selectedObj;
    int colLoop = 0; 

    private void Start()
    {
        viewCamera = Camera.main;
        //tbd change cursor to held icon 
        //crosshairAnimator = crosshair.GetComponent<Animator>();
    }

    private bool isHeld;

    //Called when mosue clicked
    private void Update()
    {
        //When LMB clicked
        if (Input.GetMouseButton(0))
        {
            //tbd replace item without letting go of previous
            /*
             * problem to solve here is to re-enable colliders in a manner
             * similar to right mouse click 
             * that in conclusion allows normal item replace-grab
             * to complete 
             */
            if (!isHeld)
            {
                //Check if mousing over item 
                Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //item within grab distance i.e. 5 units 
                if (Physics.Raycast(ray, out hit, 5))
                {
                    //Only non-kinmatic rigid body items can be picked up
                    GameObject selection = hit.transform.gameObject;
                    if (selection.GetComponent<Rigidbody>() != null &&
                        !selection.GetComponent<Rigidbody>().isKinematic &&
                        !selection.CompareTag("Immobile"))
                    {
                        //tbd add spring, possible rotation
                        selectedObj = selection;
                        //selection.transform.position = gameObject.transform.position;
                        isHeld = true;
                        colLoop = 0;
                    }
                }
            }
        }
        //keep held item following designated hold position 
        if (isHeld)
        {
            selectedObj.transform.position = gameObject.transform.position;
            //Disable colliders to prevent unwanted bumping into things
            foreach(Collider col in selectedObj.GetComponents<Collider>())
            {
                col.enabled = false;
            }
        }
        //RMB clicked to release 
        if (Input.GetMouseButton(1) && isHeld)
        {
            selectedObj.transform.position = gameObject.transform.position;
            //re-enable colliders so item doesn't fall through ground
            foreach (Collider col in selectedObj.GetComponents<Collider>())
            {
                col.enabled = true;
                colLoop++; 

            }
            //Only release item when all colliders are enabled
            /*
             * to explain, the update function fires once per frame
             * the process of enabling all colliders will take some time 
             * to process and execute, if item released before it is done
             * item will fall through ground
             */
            if(colLoop == selectedObj.GetComponents<Collider>().Length)
            {
                isHeld = false;
                selectedObj = null;
            }
                
        }
        
    }
}
