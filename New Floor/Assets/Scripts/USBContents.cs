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
    public override void Activate()
    {
        base.Activate();
        usbDelivery.IsActive = true;
    }
}
