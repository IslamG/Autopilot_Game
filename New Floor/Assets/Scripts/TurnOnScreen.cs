using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class TurnOnScreen : MonoBehaviour
{

    private VideoPlayer vidPlayer;
    public GameObject loginScreen, crosshair, screen;
    public Camera closeUpCamera, screenCamera;
    private Camera mainCam;
    public RenderTexture content;

    void Start()
    {
        //initialize variables
        Cursor.lockState = CursorLockMode.Locked;
        vidPlayer.loopPointReached += EndReached;
        mainCam = Camera.main;
    }
    private void Awake()
    {
        vidPlayer = GetComponentInChildren<VideoPlayer>();
        vidPlayer.targetTexture.Release();
    }
    public void OnMouseDown()
    {
        //if mouse is over a screen that can open 
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Debug.Log(gameObject.name+" is on");
        //Play start up animation
        vidPlayer.Play();
        //change view to close up of screen
        closeUpCamera.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        crosshair.SetActive(false);
    }
    //When startup animation finished playing
    void EndReached(VideoPlayer videoPlayer)
    {
        Debug.Log("Screen is visible");
        //Showlogin screen
        loginScreen.SetActive(true);
        screenCamera.gameObject.SetActive(true);
        //closeUpCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        //screen.GetComponent<ClickToScreen>().enabled = true;
        //clear screen and revert back to main camera
        content.DiscardContents();
        mainCam.gameObject.SetActive(true);
        this.enabled = false;
    }
}
