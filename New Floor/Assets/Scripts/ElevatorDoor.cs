using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public Animator anim;
    private bool doorOpen = false;

    public void Start()
    {
        //anim = GetComponent<Animator>();
    }
    public void OnMouseDown()
    {
        doorOpen = !doorOpen;
        if (doorOpen)
        {
            anim.Play("ElevatorOpen");
            transform.Translate(-0.01f, 0, 0, Space.Self);
        }
        else
        {
            anim.Play("ElevatorClose");
            transform.Translate(+0.01f, 0, 0, Space.Self);
        }
    }
}
