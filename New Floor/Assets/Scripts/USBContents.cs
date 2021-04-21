using UnityEngine;

public class USBContents : Puzzle
{
    [SerializeField]
    Puzzle moneyTask, usbDelivery;

    private bool isDownloaded = false;

    public bool IsViewed { get; set; } = false;

    public void ViewContents()
    {
        IsViewed = true;
        if (moneyTask.IsActive && isDownloaded)
        {
            Activate();
        }
    }
    public void ShowContentsInFolder()
    {
        isDownloaded = true;
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
