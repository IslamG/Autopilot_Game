using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JeremyPuzzle : LoginScreen
{
    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    private GameObject desktop;

    protected new void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
    }
    //Bring up login screen UI
    protected new void SwitchToScreen()
    {
        fpc.enabled = false;
        base.SwitchToScreen();
        
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


        

        //return true;
    }

    public override void Login()
    {
        if (isUnlocked)
        {
            taskMenu.RemoveTaskFromList(task);
            MakeVisible(false);
            if (desktop != null)
            {
               desktop.SetActive(true);
               desktop.GetComponent<DesktopScreen>().ShowDesktop();
               Debug.Log("Showed desktop, source: " + name);
            }
        }
    }
}
