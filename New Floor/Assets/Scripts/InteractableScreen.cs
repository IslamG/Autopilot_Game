using UnityEngine;
using UnityEngine.Video;


public abstract class InteractableScreen : PathStarter 
{ 
    [SerializeField]
    protected GameObject crosshair;
    [SerializeField]
    protected TaskMenu taskMenu;
    [SerializeField]
    protected Task task;
    [SerializeField]
    protected Camera[] sceneCameras;
    [SerializeField]
    protected Camera screenCamera;
    [SerializeField]
    protected VideoPlayer vid;
    [SerializeField]
    protected RenderTexture rend;

    public static GameObject ScreenToShow { get; set; }


    //Switch from login screen UI to normal game view
    protected void Update()
    {
        //right click to back out of screen
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused)
        {
            MakeVisible(false);
        }
    }

    //Called by loginscreen loginbutton OnClick
    //Performs login action
    //{
    //if (isUnlocked)
    //{

    //taskMenu.RemoveTaskFromList(task);
    //if (fpc != null)
    //{
    //    fpc.enabled = true;
    //}
    // MakeVisible(false);
    //Trigger fade out of scene
    //if (fadeBlack != null)
    //{
    //    fadeBlack.gameObject.SetActive(true);
    //    fadeBlack.GetComponent<FadeBlack>().Fade();
    //}

    //}
    //}
    //Call to show/hide the login screen
    public void MakeVisible(bool ctrl)
    {
        //if hiding the UI lock the mouse and reactivate the crosshair
        if (!ctrl)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crosshair.SetActive(true);
            //find and turn main camera on
            foreach (Camera cam in sceneCameras)
            {
                if (cam == Camera.main)
                {
                    cam.gameObject.SetActive(true);
                    break;
                }
            }
        }
        else
        {
            //While login screen active disable extra cameras in scene
            foreach (Camera cam in sceneCameras)
            {
                cam.gameObject.SetActive(!ctrl);
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crosshair.SetActive(false);
        }
        //Clicking on screen while vid playing will bring up login
        //stop video in that case
        if (vid.isPlaying)
        {
            vid.Stop();
            rend.DiscardContents();
        }
        ScreenToShow.SetActive(ctrl);
    }
    public void SwitchToLogin()
    {
        //Show login screen
        //loginScreen.GetComponent<LoginScreen>().MakeVisible(true);
        MakeVisible(true);
        //screenCamera.GetComponent<AudioListener>().enabled = true;
        //screenCamera.GetComponent<AudioListener>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        
        Debug.Log("Cursor: " + Cursor.lockState + " is visible " + Cursor.visible
            + " from " + gameObject.name);
    }
}