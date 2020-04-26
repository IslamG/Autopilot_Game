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
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Debug.Log(gameObject.name+" is on");
        vidPlayer.Play();
        closeUpCamera.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        crosshair.SetActive(false);
    }
    void EndReached(VideoPlayer videoPlayer)
    {
        Debug.Log("Screen is visible");
        loginScreen.SetActive(true);
        screenCamera.gameObject.SetActive(true);
        //closeUpCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        //screen.GetComponent<ClickToScreen>().enabled = true;
        content.DiscardContents();
        mainCam.gameObject.SetActive(true);
        this.enabled = false;
    }
}
