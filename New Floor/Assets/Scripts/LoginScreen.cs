using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System;

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
            MakeVisible(false);
            //Add pan out animation
            foreach (Camera cam in sceneCameras)
            {
                if (cam == Camera.main)
                {
                    Debug.Log("Why am I here");
                    cam.gameObject.GetComponent<Animator>().SetBool("isWaiting", false);
                    break;
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
            //find and turn main camera on
            foreach(Camera cam in sceneCameras)
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
