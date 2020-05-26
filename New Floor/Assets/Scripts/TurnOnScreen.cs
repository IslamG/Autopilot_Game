using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using TMPro;
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

    void Start()
    {
        //initialize variables
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        vidPlayer.loopPointReached += EndReached;
        mainCam = Camera.main;
    }
    //Switch view from closeup camera to main 
    private void Update()
    {
        //Back out of login screen on right click if up
        if(Input.GetMouseButton(1) && closeUpCamera.isActiveAndEnabled && !loginScreen.activeSelf)
        {
            mainCam.gameObject.SetActive(true);
            closeUpCamera.gameObject.SetActive(false);
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
            closeUpCamera.gameObject.SetActive(true);
            mainCam.gameObject.SetActive(false);
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
        //Show login screen
        loginScreen.GetComponent<LoginScreen>().MakeVisible(true);
        screenCamera.gameObject.SetActive(true);

        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //clear screen and revert back to main camera
        //for viewing login screen
        content.DiscardContents();
        //remove?
        mainCam.gameObject.SetActive(true);
    }
}
