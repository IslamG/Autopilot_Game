using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBContents : Puzzle
{
    [SerializeField]
    Puzzle moneyTask, usbDelivery;

    public bool IsViewed { get; set; } = false;

    public void ViewContents()
    {
        IsViewed = true;
        if (moneyTask.IsActive)
        {
            Activate();
        }
    }
    public override void Solve()
    {
        moneyTask.Solve();
        base.Solve();
    }
    protected override void Activate()
    {
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();
        usbDelivery.IsActive = true;
    }
}
