using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Package : PathStarter
{
    public delegate void DelegateFunc();
    DelegateFunc del;

    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    Puzzle moneyTask;
    [SerializeField]
    GameObject arrow;

    private bool shown = false;
    public static bool PackageOpened { get; set; } = false;

    //When a package is clicked, show pop up prompting to open
    protected new void OnMouseDown()
    {

        //If pop up hasn't been shown before
        if (!shown)
        {
            base.OnMouseDown();
            //Show pop up, disable movement, and show cursor
            PopUp pop = gameObject.GetComponent<PopUp>();
            Debug.Log("pp " + pop.MessageHeader);
            pop.ShowPop();
            del = AskToOpen;
            fpc.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
            popUpGen.gameObject.SetActive(true);
            shown = true;
        }
    }
    //Method to redirect to when decision made in pop up
    private void AskToOpen()
    {
        //Allow movement, hide cursor, and trigger decision consequences
        fpc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("!");
        if (!PackageOpened || !moneyTask.IsActive)
        {
            //Do something later
            Debug.Log("Opened Package");
            DropItem di = gameObject.GetComponent<DropItem>();

            foreach (DropSpot spot in di.TargetSpot)
            {
                //di.TargetSpot
                if (spot.gameObject.CompareTag("JeremyPuzzle"))
                {
                    spot.gameObject.SetActive(false);
                }
            }

        }
    }
    public override void Activate()
    {
        base.Activate();

        arrow.SetActive(false);
        pathActivated.Invoke(JeremyPath.instance);

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

        //return true;
    }
}
