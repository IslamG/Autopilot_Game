using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JeremyMonitor : InteractableScreen
{

    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    protected GameObject loginScreen;
 
    protected new void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
    }
    protected new void Update()
    {
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused)
        {
            fpc.enabled = true;
            MakeVisible(false);
        }
    }

    //protected new void OnMouseDown()
    //{
    //    base.OnMouseDown();
    //}
       
    //Bring up login screen UI
    public override void SwitchToScreen()
     {
        fpc.enabled = false;
        Debug.Log("Switch to screen from Jeremy ");
        base.SwitchToScreen();
        //this.enabled = false;
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
}
