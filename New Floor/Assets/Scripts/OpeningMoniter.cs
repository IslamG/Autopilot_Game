using cakeslice;
using UnityEngine;
using UnityEngine.UI;

public class OpeningMoniter : InteractableScreen
{
    [SerializeField]
    private Camera  closeUpCamera;
    [SerializeField]
    private OutlineEffect outline;
    
    [SerializeField]
    protected GameObject loginScreen;
    


    private Camera mainCam;
    protected new void Start()
    {
        base.Start();
        mainCam = Camera.main;
        outline = mainCam.GetComponent<OutlineEffect>();
        ScreenToShow = loginScreen;
    }
    //Switch view from closeup camera to main 
    protected new void Update()
    {
        //Back out of login screen on right click if up
        if(Input.GetMouseButton(1) && closeUpCamera.isActiveAndEnabled 
            && !loginScreen.activeSelf && !PauseMenu.isPaused)
        {
            mainCam.gameObject.SetActive(true);
            mainCam.GetComponent<AudioListener>().enabled = true;
            closeUpCamera.gameObject.SetActive(false);
            closeUpCamera.GetComponent<AudioListener>().enabled = false;
        }
        base.Update();
    }
    protected new void OnMouseDown()
    {
        base.OnMouseDown();
        //Click on screen not login interface
        if (!loginScreen.activeSelf)
        {
            //change view to close up of screen
             closeUpCamera.gameObject.SetActive(true);
             closeUpCamera.GetComponent<AudioListener>().enabled = true;
             mainCam.gameObject.SetActive(false);
             mainCam.GetComponent<AudioListener>().enabled = false;
            Debug.Log("Doing on Mouse down from opening puzzle from " + gameObject.name);
        }

    }
    //Bring up login screen UI
    protected new private void SwitchToLogin()
    {
        outline.enabled = false;
        screenCamera.gameObject.SetActive(true);
        base.SwitchToLogin();
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
}
