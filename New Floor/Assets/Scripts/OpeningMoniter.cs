using cakeslice;
using UnityEngine;

public class OpeningMoniter : InteractableScreen
{
    [SerializeField]
    private Camera closeUpCamera;
    [SerializeField]
    private OutlineEffect outline;

    [SerializeField]
    protected GameObject loginScreen;

    private Camera mainCam;
    protected override void Start()
    {
        base.Start();
        mainCam = Camera.main;
        outline = mainCam.GetComponent<OutlineEffect>();
        ScreenToShow = loginScreen;
        Debug.Log("Intializing opening monitor screen to show = " + loginScreen);

    }
    //Switch view from closeup camera to main 
    protected new void Update()
    {
        //Back out of login screen on right click if up
        if (Input.GetMouseButton(1)   && !PauseMenu.isPaused) //&& !loginScreen.activeSelf
        {
            Debug.Log("Update inside of opening monitor");
            if (closeUpCamera.isActiveAndEnabled)
            {
                mainCam.gameObject.SetActive(true);
                mainCam.GetComponent<AudioListener>().enabled = true;
                closeUpCamera.gameObject.SetActive(false);
                closeUpCamera.GetComponent<AudioListener>().enabled = false;
            }
            
            if(IsUp)
                MakeVisible(false);
        }
        
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
        }

    }
    //Bring up login screen UI
    public override void SwitchToScreen()
    {
        outline.enabled = false;
        screenCamera.gameObject.SetActive(true);
        base.SwitchToScreen();
    }
}
