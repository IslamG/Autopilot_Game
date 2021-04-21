using UnityEngine;
using UnityEngine.Video;


public class InteractableScreen : Puzzle
{
    [SerializeField]
    protected GameObject crosshair, objectiveArrow;
    //[SerializeField]
    //protected Task task;
    [SerializeField]
    protected Camera[] sceneCameras;
    [SerializeField]
    protected Camera screenCamera;
    [SerializeField]
    protected VideoPlayer vid;
    [SerializeField]
    protected RenderTexture rend;

    public GameObject ScreenToShow { get; set; }
    public bool IsUp { get; set; } = false;

    private  void Awake()
    {
        ScreenToShow = gameObject;
    }

    //Switch from login screen UI to normal game view
    protected void Update()
    {
        //right click to back out of screen
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused && IsUp)
        {
            Debug.Log("In interactable screen update for some reason");
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
                Debug.Log("Locking inter screen mouse from: " + gameObject.name);
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
                if (objectiveArrow != null)
                    objectiveArrow.SetActive(true);
            }
            else
            {
                Debug.Log("Unlocking inter screen mouse from: " + gameObject.name);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                //While login screen active disable extra cameras in scene
                foreach (Camera cam in sceneCameras)
                {
                    cam.gameObject.SetActive(!ctrl);
                }
                
                crosshair.SetActive(false);
                if(objectiveArrow!=null)
                    objectiveArrow.SetActive(false);
            }
            //Clicking on screen while vid playing will bring up login
            //stop video in that case
            if (vid != null)
            {
                if (vid.isPlaying)
                {
                    vid.Stop();
                    rend.DiscardContents();
                }
            }
            IsUp = ctrl;
            Debug.Log(" I'm " + this.name+" Interactable Screen Making visible " + ctrl+" "+ScreenToShow );
            ScreenToShow.SetActive(ctrl);
        }

    }
    public virtual void SwitchToScreen()
    {
        if (IsEnabled)
        {
            Debug.Log("In Switch to Screen Interactable for some reason");
            //Show login screen
            MakeVisible(true);
        }

    }
}