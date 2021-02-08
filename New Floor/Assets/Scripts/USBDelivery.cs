using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBDelivery : Puzzle
{
    [SerializeField]
    SecutiryPuzzle security;
    [SerializeField]
    USBContents usbContents;
    [SerializeField]
    TipsControl tipControl;

    private new void OnMouseDown()
    {
        if (usbContents.IsViewed)
        {
            base.OnMouseDown();
        }
    }
    public override void Solve()
    {
        usbContents.Solve();
        Debug.Log("Solve Solve usb delivery");
        base.Solve();
    }
    protected override void Activate()
    {
            //Activate task based on attached task 
            Task task = gameObject.GetComponent<Task>();
            //Invokes task listeners
            task.ActivateTask();
            security.ShowCones();
        TipScript tip = gameObject.GetComponent<TipScript>(); ;
        tipControl.GenerateTip(tip);


        //Activate drop spot for tasks with drop spots
        DropItem di = gameObject.GetComponent<DropItem>();
        //if dropppable object
        if (!task.IsCompleted)
        {
            foreach (DropSpot spot in di.TargetSpot)
            {
                //di.TargetSpot
                spot.gameObject.SetActive(true);
            }
        }

    }
}
