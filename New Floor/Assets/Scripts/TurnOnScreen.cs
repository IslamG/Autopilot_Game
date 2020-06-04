using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using TMPro;
using cakeslice;
using UnityEngine.SceneManagement;

public class TurnOnScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject loginScreen, crosshair;
    [SerializeField]
    private Camera closeUpCamera, screenCamera;
    [SerializeField]
    private RenderTexture content;
    [SerializeField]
    private TMP_Text helperText;
    [SerializeField]
    TipsControl tipControl;

    private VideoPlayer vidPlayer;
    private Camera mainCam;
    private static bool introVideoPlayed = false, helperDisplayed = false;
    private Timer textTimer;
    [SerializeField]
    private OutlineEffect outline;

    void Start()
    {
        //initialize variables
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        vidPlayer.loopPointReached += EndReached;
        mainCam = Camera.main;
        outline = mainCam.GetComponent<OutlineEffect>();
        //Debug.Log(outline.enabled);
    }
    //Switch view from closeup camera to main 
    private void Update()
    {
        //Back out of login screen on right click if up
        if (closeUpCamera != null)
        {
            if(Input.GetMouseButton(1) && closeUpCamera.isActiveAndEnabled 
                && !loginScreen.activeSelf && !PauseMenu.isPaused)
            {
                mainCam.gameObject.SetActive(true);
                mainCam.GetComponent<AudioListener>().enabled = true;
                closeUpCamera.gameObject.SetActive(false);
                closeUpCamera.GetComponent<AudioListener>().enabled = false;
            }
        }
        
        //Hide helper text after duration
        if (textTimer.Finished && helperDisplayed)
        {
            helperText.text = "";
        }
    }
    private void Awake()
    {
        vidPlayer = GetComponentInChildren<VideoPlayer>();
        vidPlayer.targetTexture.Release();
        textTimer = gameObject.AddComponent<Timer>();
        textTimer.Duration = 5;
    }
    public void OnMouseDown()
    {
        //if mouse isn't over a screen that can open 
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Debug.Log(gameObject.name+" is on");
        if (SceneManager.GetActiveScene().name.Equals("Opening"))
            tipControl.GenerateTip(this.gameObject.GetComponent<TipScript>());
        //Only play the boot up animation once
        if (!introVideoPlayed)
        {
            //Play start up animation
            vidPlayer.Play();
            introVideoPlayed = true;
        }
        else
        {
            SwitchToLogin();
        }
        //Click on screen not login interface
        if (!loginScreen.activeSelf)
        {
            //change view to close up of screen
            if (closeUpCamera != null)
            {
                closeUpCamera.gameObject.SetActive(true);
                closeUpCamera.GetComponent<AudioListener>().enabled = true;
                mainCam.gameObject.SetActive(false);
                mainCam.GetComponent<AudioListener>().enabled = false;
            }
        }
               
    }
    //When startup animation finished playing
    void EndReached(VideoPlayer videoPlayer)
    {
        SwitchToLogin();
        //Display helper text only once
        if (!helperDisplayed)
        {
            helperText.text = "I think I wrote clues to my password somewhere";
            textTimer.Run();
            helperDisplayed = true;
        }
    }
    //Bring up login screen UI
    private void SwitchToLogin()
    {
        //Destroy(outline);
        //Debug.Log(outline);
        if(outline!=null)
            outline.enabled = false;

        //Show login screen
        loginScreen.GetComponent<LoginScreen>().MakeVisible(true);
        screenCamera.gameObject.SetActive(true);
        //screenCamera.GetComponent<AudioListener>().enabled = true;
        //screenCamera.GetComponent<AudioListener>().enabled = true;

        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //clear screen and revert back to main camera
        //for viewing login screen
        content.DiscardContents();
        //remove?
        mainCam.gameObject.SetActive(true);
        mainCam.GetComponent<AudioListener>().enabled = true;
    }
}
