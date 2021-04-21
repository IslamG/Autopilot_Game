using TMPro;
using UnityEngine;


public abstract class LoginScreen : InteractableScreen
{
    [SerializeField]
    protected TMP_InputField passField;
    [SerializeField]
    protected GameObject loginScreen;
    [SerializeField]
    protected Task[] taskToRemove;
    [SerializeField]
    protected AudioClip confirm, deny;
    [SerializeField]
    protected AudioSource source;

    //tbd simplify password
    protected string password = "1234";//"28212433110";
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
            source.PlayOneShot(confirm);
        }
        else
        {
            source.PlayOneShot(deny);
        }
    }
    //Called by loginscreen loginbutton OnClick
    //Performs login action
    public abstract void Login();
    protected void DisableScreen()
    {
        if (isUnlocked)
        {
            //taskMenu.RemoveTaskFromList(task);
            Solve();
            MakeVisible(false);
        }
    }

}
