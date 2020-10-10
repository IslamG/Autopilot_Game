using UnityEngine;
using TMPro;


public abstract class LoginScreen : InteractableScreen
{
    [SerializeField]
    protected TMP_InputField passField;
    [SerializeField]
    protected GameObject loginScreen;


    //tbd simplify password
    protected const string password = "1234";//"28212433110";
    protected string input = "";//static
    protected bool isUnlocked = false;

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
    public abstract void Login();
    /*{
        if (isUnlocked)
        {
            
            taskMenu.RemoveTaskFromList(task);
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
                    Debug.Log("Showed desktop, source: "+name);
                }
            }
            
        }
    }*/
    protected  void DisableScreen()
    {
        if (isUnlocked)
        {
            taskMenu.RemoveTaskFromList(task);
            MakeVisible(false);
        }
    }
    
}
