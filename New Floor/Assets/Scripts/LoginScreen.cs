using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField passField;
    [SerializeField]
    private GameObject crossHair;

    private const string password = "1234";
    private static string input = "";
    private bool isUnlocked = false;

    //Called by password field OnEditEnd
    //Compares password to user input
    public void WritePassword()
    {
        input = passField.text;
        if (password.Equals(input))
        {
            isUnlocked = true;
        }
    }
    //Called by loginscreen loginbutton OnClick
    //Performs login action
    public void login()
    {
        if (isUnlocked)
        {
            //tbd next minigame or scene switch
            MakeVisible(false);
        }
    }
   //Call to show/hide the login screen
   public void MakeVisible(bool control)
   {
        //if hiding the UI lock the mouse and reactivate the crosshair
        if (!control)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crossHair.SetActive(true);
        }
        gameObject.SetActive(control);
    }
    //Switch from login screen UI to normal game view
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)&&gameObject.activeSelf)
        {
            MakeVisible(false);
        }
    }
}
