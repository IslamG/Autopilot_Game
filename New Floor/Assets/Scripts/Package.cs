using System.Linq;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Package : PathStarter
{
    public delegate void DelegateFunc();
    DelegateFunc del;
    
    [SerializeField]
    FirstPersonController fpc;

    private bool shown = false;
    public static bool PackageOpened { get; set; } = false;

    //When a package is clicked, show pop up prompting to open
    protected new void  OnMouseDown()
    {
        base.OnMouseDown();
        //If pop up hasn't been shown before
        if (!shown)
        {
            //Show pop up, disable movement, and show cursor
            PopUp pop = gameObject.GetComponent<PopUp>();
            Debug.Log("pp "+pop.MessageHeader);
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
        if (!PackageOpened)
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
    protected override void Activate()
    {
        //Activate task based on attached task 
        isActive = true;
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();
        //Hides cosmatic arrow in scene, invokes path activated listeners

        arrow.SetActive(false);
        pathActivated.Invoke(JeremyPath.instance);

        //tbd show text outlining the task on activation 

        //PopUp pop = gameObject.GetComponent<PopUp>();
        //pop.MessageHeader = task.TaskText;
        //pop.ShowPop();

        //fpc.enabled = false;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;


        //tbd generic puzzle delegate method for pop up

        //popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
        //popUpGen.gameObject.SetActive(true);


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
