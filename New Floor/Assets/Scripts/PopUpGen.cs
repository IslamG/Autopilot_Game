using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    MainMenu.DelegateFunc mainFunc;

    public void GeneratePopUp(PopUp popUp)
    {
        if(popUp.MessageHeader!=null)
            messageHeader.text = popUp.MessageHeader;
        if (popUp.MessageBody != null)
            messageBody.text = popUp.MessageBody;
        Debug.Log("Thing "+popUp.MessageHeader);

        if (popUp.IncludeCancel)
        {
            cancelBtn.gameObject.SetActive(true);
        }
        okBtn.gameObject.SetActive(true);

    }
    public void Confirmation()
    {
        if (mainFunc != null)
            mainFunc.Invoke();
        this.gameObject.SetActive(false);
    }
    public void Cancel()
    {
        this.gameObject.SetActive(false);
    }
    public void FunctionToDo(MainMenu.DelegateFunc function)
    {
        mainFunc = function;
    }
}
