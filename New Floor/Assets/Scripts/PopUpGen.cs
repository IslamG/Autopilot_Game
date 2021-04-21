using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpGen : MonoBehaviour
{
    public static PopUpGen instance;
    [SerializeField]
    private TMP_Text messageHeader, messageBody;
    [SerializeField]
    private GameObject buttonHolder;
    [SerializeField]
    private Button okBtn, cancelBtn;
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private Image image;

    MainMenu.DelegateFunc mainFunc;
    PauseMenu.DelegateFunc pauseFunc;
    Package.DelegateFunc packFunc;
    SecutiryPuzzle.DelegateFunc securityFunc;

    bool isTrue, created = false;

    public string InputText { get; set; }

    void Awake()
    {
        if (!created)
        {
            //DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }

    //Function to generate and activate pop up with custom
    //message, header, and buttons
    public void GeneratePopUp(PopUp popUp)
    {
        if (popUp.IsImage)
        {
            //messageHeader.gameObject.SetActive(false);
            messageBody.gameObject.SetActive(false);
            image.sprite = popUp.DisplayImage;
            //cancelBtn.gameObject.SetActive(true);
            image.gameObject.SetActive(true);
        }
        //Assign text values from popUp object
        if (popUp.MessageHeader != null)
            messageHeader.text = popUp.MessageHeader;
        if (popUp.MessageBody != null)
            messageBody.text = popUp.MessageBody;

        //Allow cancel button if in popUp object
        if (popUp.IncludeCancel)
        {
            cancelBtn.gameObject.SetActive(true);
        }
        if (popUp.IncludeField)
        {
            inputField.gameObject.SetActive(true);
        }
        okBtn.gameObject.SetActive(true);
    }
    //Capture Text form input field
    public void CaptureText()
    {
        InputText = inputField.text;
        Debug.Log("pop input field writing: " + inputField.text);
    }
    public void ShowInputField(bool state)
    {
        inputField.gameObject.SetActive(state);
    }
    //Ok button pressed, invoke method delegated from original object
    public void Confirmation()
    {
        if (mainFunc != null)
            mainFunc.Invoke();
        if (pauseFunc != null)
            pauseFunc.Invoke();
        //Confirm means oppen package
        if (packFunc != null)
        {
            Package.PackageOpened = true;
            packFunc.Invoke();
        }
        if (securityFunc != null)
            securityFunc.Invoke();
        //Hide pop up
        LeavePopUp();
        //Debug.Log("Hiding Gen from ok");
        isTrue = true;
    }
    //Cancel button pressed, do nothing and hide pop up
    public void Cancel()
    {
        //Cancel means don't open package
        if (packFunc != null)
        {
            Package.PackageOpened = false;
            packFunc.Invoke();
        }

        //hide pop up
        gameObject.SetActive(false);
        Debug.Log("Hiding Gen from cancel");
        isTrue = false;
    }

    //FunctionToDo is the function delegated to
    //Assign delegate funciton to a variable to invoke
    //on confirmation 

    //Overload for main menu
    public void FunctionToDo(MainMenu.DelegateFunc function)
    {
        mainFunc = function;
        //LeavePopUp();
    }
    //Overload for pause menu
    public void FunctionToDo(PauseMenu.DelegateFunc function)
    {
        pauseFunc = function;
        //LeavePopUp();
    }
    //Overload for package
    public bool FunctionToDo(Package.DelegateFunc function)
    {
        packFunc = function;
        return isTrue;
    }
    //Overload for security
    public void FunctionToDo(SecutiryPuzzle.DelegateFunc function)
    {
        securityFunc = function;
        //LeavePopUp();
    }
    private void LeavePopUp()
    {
        gameObject.SetActive(false);
    }
}
