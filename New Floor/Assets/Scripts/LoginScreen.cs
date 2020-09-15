using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using System;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class LoginScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField passField;
    [SerializeField]
    private GameObject crossHair;
    [SerializeField]
    private TaskMenu taskMenu;
    [SerializeField]
    private Task task;
    [SerializeField]
    Camera[] sceneCameras;
    [SerializeField]
    private VideoPlayer vid;
    [SerializeField]
    private RenderTexture rend;
    [SerializeField]
    private Image fadeBlack;
    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    private GameObject desktop;

    //tbd simplify password
    private const string password = "1234";//"28212433110";
    private static string input = "";
    private bool isUnlocked = false; 

    //Switch from login screen UI to normal game view
    private void Update()
    {
        //right click to back out of screen
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused)
        {
            MakeVisible(false);
        }
    }
    //Called by password field OnEditEnd
    //Compares password to user input
    public void WritePassword()
    {
        //On correct password input unlock and mark task as successful
        input = passField.text;
        if (password.Equals(input))
        {
            isUnlocked = true;
        }
    }
    //Called by loginscreen loginbutton OnClick
    //Performs login action
    public void Login()
    {
        if (isUnlocked)
        {
            
            taskMenu.RemoveTaskFromList(task);
            if (fpc != null)
            {
                fpc.enabled = true;
            }
            MakeVisible(false);
            //Trigger fade out of scene
            if (fadeBlack != null)
            {
                fadeBlack.gameObject.SetActive(true);
                fadeBlack.GetComponent<FadeBlack>().Fade();
            }
            else
            {
                if (desktop != null)
                {
                    desktop.SetActive(true);
                    desktop.GetComponent<DesktopScreen>().ShowDesktop();
                    Debug.Log("Dunzo");
                }
            }
            
        }
    }

   //Call to show/hide the login screen
   public void MakeVisible(bool ctrl)
   {
        //if hiding the UI lock the mouse and reactivate the crosshair
        if (!ctrl)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crossHair.SetActive(true);
            if (fpc != null)
            {
                fpc.enabled = true;
            }
            Debug.Log("Did");
            //find and turn main camera on
            foreach(Camera cam in sceneCameras)
            {
                //tbd move audio listener management to new manager

                //if (cam.name.Equals("ScreenCamera"))
                //{
                 //   cam.GetComponent<AudioListener>().enabled = false;
                //}
                if (cam == Camera.main)
                {
                    cam.gameObject.SetActive(true);
                   // cam.GetComponent<AudioListener>().enabled = true;
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
                //cam.GetComponent<AudioListener>().enabled = !ctrl;
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Did2 "+Cursor.lockState);
        }
        //Clicking on screen while vid playing will bring up login
        //stop video in that case
        if (vid.isPlaying)
        {
            vid.Stop();
            rend.DiscardContents();
        }
        gameObject.SetActive(ctrl);
    }
}
