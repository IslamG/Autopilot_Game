using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TurnOnScreen : MonoBehaviour
{

    private VideoPlayer vidPlayer;
    public GameObject loginScreen;
    [SerializeField]
    private Camera closeUpCamera, screenCamera;
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private RenderTexture content;
    public GameObject screen;
    private void Awake()
    {
        vidPlayer = GetComponentInChildren<VideoPlayer>();
        vidPlayer.targetTexture.Release();
    }
    public void OnMouseDown()
    {
        Debug.Log(gameObject.name+" is on");
        vidPlayer.Play();
        closeUpCamera.gameObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);
        crosshair.SetActive(false);
    }
    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        vidPlayer.loopPointReached += EndReached;    
    }
    void EndReached(VideoPlayer videoPlayer)
    {
        Debug.Log("Screen is visible");
        //loginScreen.SetActive(true);
        screenCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        screen.GetComponent<ClickToScreen>().enabled = true;
        content.DiscardContents();

    }
}
