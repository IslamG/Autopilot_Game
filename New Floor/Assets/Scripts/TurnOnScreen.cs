using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;
public class TurnOnScreen : MonoBehaviour
{
    
    
    [SerializeField]
     RenderTexture content;
    [SerializeField]
     TMP_Text helperText;
    [SerializeField]
     TipsControl tipControl;

     VideoPlayer vidPlayer;
     Camera mainCam;
     static bool introVideoPlayed = false, helperDisplayed = false;
     Timer textTimer;
     InteractableScreen openUI;

    void Start()
    {
        //initialize variables
        //base.Start();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        vidPlayer.loopPointReached += EndReached;
        mainCam = Camera.main;
        openUI= gameObject.GetComponent<InteractableScreen>();
    }
    //Switch view from closeup camera to main 
    void Update()
    {
        //base.Update();
        //Hide helper text after duration
        if (textTimer.Finished && helperDisplayed)
        {
            helperText.text = "";
        }
    }
    void Awake()
    {
        vidPlayer = GetComponentInChildren<VideoPlayer>();
        vidPlayer.targetTexture.Release();
        textTimer = gameObject.AddComponent<Timer>();
        textTimer.Duration = 5;
    }
    void OnMouseDown()
    {
        //base.OnMouseDown();
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
            openUI.SwitchToLogin();
            //clear screen and revert back to main camera
            //for viewing login screen
            content.DiscardContents();
            //remove?
            mainCam.gameObject.SetActive(true);
            //mainCam.GetComponent<AudioListener>().enabled = true;
        }
    }
    //When startup animation finished playing
    void EndReached(VideoPlayer videoPlayer)
    {
        openUI.SwitchToLogin();

        //Display helper text only once
        if (!helperDisplayed && helperText!=null)
        {
            helperText.text = "I think I wrote clues to my password somewhere";
            textTimer.Run();
            helperDisplayed = true;
        }
    }
    /*
    //Bring up login screen UI
    private void SwitchToLogin()
    {
        gameObject.GetComponent<InteractableScreen>().SwitchToLogin();
        //clear screen and revert back to main camera
        //for viewing login screen
        content.DiscardContents();
        //remove?
        mainCam.gameObject.SetActive(true);
        //mainCam.GetComponent<AudioListener>().enabled = true;
    }*/
}
