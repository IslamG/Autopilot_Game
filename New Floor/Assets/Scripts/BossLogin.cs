using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogin : LoginScreen
{
    [SerializeField]
    protected GameObject desktopScreen;

    protected new void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
        password = "5678";
    }

    public override void Login()
    {
        if (isUnlocked)
        {
            if (taskToRemove != null)
            {
                foreach (Task task in taskToRemove)
                {
                    taskMenu.RemoveTaskFromList(task);
                }
            }
            //Activate();
            MakeVisible(false);
            if (desktopScreen != null)
            {
                desktopScreen.SetActive(true);
                desktopScreen.GetComponent<SecurityScreen>().ShowDesktop();
            }
            //DisableScreen();
            this.enabled = false;
        }
    }
    protected override void Activate()
    {
        isActive = true;
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();
        //Hides cosmatic arrow in scene, invokes path activated listeners
        //arrow.SetActive(false);
        //pathActivated.Invoke(JeremyPath.instance);

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
}
