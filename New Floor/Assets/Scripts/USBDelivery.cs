using UnityEngine;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;

public class USBDelivery : Puzzle
{
    [SerializeField]
    SecutiryPuzzle security;
    [SerializeField]
    USBContents usbContents;
    [SerializeField]
    TipsControl tipControl;
    [SerializeField]
    AdventurePath jeremyPath;
    [SerializeField]
    GameObject credits;
    [SerializeField]
    FirstPersonController fpc;

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
        jeremyPath.PathObjectEarned(jeremyPath, this);
        fpc.CanMove = false;
        credits.SetActive(true);
        credits.GetComponent<VideoPlayer>().Play();
    }
    public override void Activate()
    {
        if (!isActive)
        {
            base.Activate();

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
}
