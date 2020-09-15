using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private string messageHeader, messageBody;
    [SerializeField]
    private bool  includeCancel;
    [SerializeField]
    private PopUpGen popUpGen;

    public string MessageHeader { get => messageHeader; set => messageHeader = value; } 
    public string MessageBody { get => messageBody; set => messageBody = value; }
    public bool IncludeCancel { get => includeCancel; set => includeCancel = value; }

    //Call handler for generating a popUp with information in class
    public void ShowPop()
    {
        popUpGen.GeneratePopUp(this);
    }
}
