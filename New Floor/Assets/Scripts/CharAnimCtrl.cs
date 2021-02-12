using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CharAnimCtrl : Sit
{
    private Animator anim;
    private Camera cam;
    private bool isSitting = false, isCrouched = false;
    private FirstPersonController fpc;

    //Initialize variables
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        cam = Camera.main;
        fpc = GetComponentInParent<FirstPersonController>();
    }
    //Wait until input and switch animator state accordingly
    void Update()
    {
        Vector3 camPos = cam.transform.localPosition;
        //Movement key pressed
        //tbd replace with motion axis
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            //State 1: Walk cycle
            anim.SetInteger("motionState", 1);
        }

        //tbd add in run button and animation

        //Jump key pressed
        //tbd replace with jump button axis
        else if (Input.GetKey("space"))
        {
            //State 3: Jump animation
            anim.SetInteger("motionState", 3);
        }
        //Crouch key pressed
        //tbd replace with crouch button axis
        /*else if (Input.GetKey("left ctrl"))
        {
            //Switch states, if standing crouch and vice versa
            if (!isCrouched)
            {
                //State 4: crouch animation
                //Move camera to crouched level
                anim.SetInteger("motionState", 4);
                cam.transform.localPosition = new Vector3(0, -0.25f, 0);
                isCrouched = true;
            }
            else
            {
                //State 5: Stand animation
                anim.SetInteger("motionState", 5);
                //cam.transform.localPosition = camPos;
                isCrouched = false;
            }
        }*/
        //tbd replace with sit button
        /*else if (Input.GetKey("j"))
        {
            //Check if character is in an area they can sit (chairs)
            if (base.CanSit())
            {
                //State 6: sit animation
                anim.SetInteger("motionState", 6);
                cam.transform.localPosition = new Vector3(0, 0.8f, 0);
                isSitting = true;
                fpc.CanMove = false;
                fpc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
        //tbd stand button
        else if (Input.GetKey("k"))
        {
            //if is sitting allow to stand
            if (base.CanSit() && isSitting)
            {
                //State 7: stand animation
                anim.SetInteger("motionState", 7);
                cam.transform.localPosition = camPos;
                isSitting = false;
                fpc.CanMove = true;
                fpc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }*/
        else
        {
            //Default to idle stance 
            //If needed so that a sitting or crouched character is left in that state
            //    if (!isSitting && !isCrouched)
            //    {
            //State 0: Idle animation
            anim.SetInteger("motionState", 0);
            cam.transform.localPosition = camPos;
            //   }
        }
    }
}
