using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private bool doorOpen = false;

    public bool IsEnabled { get; set; } = true;

    //When elevator button clicked
    void OnMouseDown()
    {
        if (IsEnabled)
        {
            //Switch door states
            doorOpen = !doorOpen;
            //Play correct animation for state
            //And push button in or out accordingly
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
}
