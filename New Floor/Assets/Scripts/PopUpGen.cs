using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class PopUpGen : MonoBehaviour
{
    public static PopUpGen instance; 

    [SerializeField]
    private TMP_Text message;
    [SerializeField]
    private GameObject buttonHolder;
    [SerializeField]
    private Button okBtn, cancelBtn;

    public void GeneratePopUp(PopUp popUp)
    {
        message.text = popUp.Message;
        Debug.Log("Thing "+popUp.Message);
        //for (int i = 0; i < popUp.BtnCount; i++)
        //{
        if (popUp.IncludeCancel)
        {
            cancelBtn.gameObject.SetActive(true);
        }
        okBtn.gameObject.SetActive(true);
        //
    }
    public void Confirmation()
    {
        Debug.Log("Confirmed");
    }
    public void Cancel()
    {
        Debug.Log("Canceled");
    }
}
