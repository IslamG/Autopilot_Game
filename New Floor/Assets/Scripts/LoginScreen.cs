using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    private const string password = "1234";
    private static string input = "";
    private bool isUnlocked = false; 

    //Switch from login screen UI to normal game view
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && gameObject.activeSelf)
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
            //Load next scene
            SceneManager.LoadScene("LoadingScreen");
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
        }
        gameObject.SetActive(ctrl);
    }
}
