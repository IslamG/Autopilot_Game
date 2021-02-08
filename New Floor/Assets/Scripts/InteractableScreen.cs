using UnityEngine;
using UnityEngine.Video;


public abstract class InteractableScreen : PathStarter 
{ 
    [SerializeField]
    protected GameObject crosshair;
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

    public GameObject ScreenToShow { get; set; }

    //Switch from login screen UI to normal game view
    protected void Update()
    {
        //right click to back out of screen
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused)
        {
            MakeVisible(false);
        }
    }

    //Call to show/hide the login screen
    public void MakeVisible(bool ctrl)
    {
        if (IsEnabled)
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
            Debug.Log("Interactable Screen Making visible " + ScreenToShow);
            ScreenToShow.SetActive(ctrl);
        }
        
    }
    public virtual void SwitchToScreen()
    {
        if (IsEnabled)
        {
             //Show login screen
            MakeVisible(true);
        }
        
    }
}