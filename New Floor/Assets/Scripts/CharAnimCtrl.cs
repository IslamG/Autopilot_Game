using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimCtrl : Sit
{
    private Animator anim;
    private Camera cam;
    private bool isSitting=false, isCrouched= false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = cam.transform.localPosition;
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            anim.SetInteger("motionState",1);
        } else if (Input.GetKey("space"))
        {
            anim.SetInteger("motionState", 3);
        }
        else if (Input.GetKey("left ctrl"))
        {
            if (!isCrouched)
            {
                anim.SetInteger("motionState", 4);
                cam.transform.localPosition = new Vector3(0, -0.25f, 0);
                isCrouched = true;
            }
            else
            {
                anim.SetInteger("motionState", 5);
                //cam.transform.localPosition = camPos;
                isCrouched = false;
            }
        }
        else if (Input.GetKey("j"))
        {
            if (base.CanSit())
            {
                anim.SetInteger("motionState", 6);
                cam.transform.localPosition = new Vector3(0, 0.8f, 0);
                isSitting = true;
            }
        }
        else if (Input.GetKey("k"))
        {
            if (base.CanSit() && isSitting)
            {
                anim.SetInteger("motionState", 7);
                cam.transform.localPosition = camPos;
                isSitting = false;
            }
        }
        else
        {
            if (!isSitting && !isCrouched)
            {
                anim.SetInteger("motionState", 0);
                cam.transform.localPosition = camPos;
            }

        }
    }
}
