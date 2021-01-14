using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DesktopScreen : InteractableScreen
{
    [SerializeField]
    FirstPersonController fpc;
    /*
    protected override void DisableScreen()
    {
        if (isUnlocked)
        {

            taskMenu.RemoveTaskFromList(task);
            fpc.enabled = true;
            MakeVisible(false);
        }
    }
    public new void MakeVisible(bool ctrl)
    {
        //if hiding the UI lock the mouse and reactivate the crosshair
        if (!ctrl)
        {
            base.MakeVisible(ctrl);
            fpc.enabled = true;
        }
        else
        {
            fpc.enabled = false;
            base.MakeVisible(ctrl);
        }
    }*/
    public void HideDesktop()
    {
        MakeVisible(false);
    }
    public void ShowDesktop()
    {
        MakeVisible(true);
        if (!IsActive)
        {
            Activate();
        }
    }

    protected override void Activate()
    {
        //Activate task based on attached task 
        isActive = true;
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();

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




        //return true;
    }
    /*protected override void DisableScreen()
    {
        HideDesktop();
    }*/
}
