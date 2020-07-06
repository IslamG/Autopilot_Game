using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private string messageHeader, messageBody;
    [SerializeField]
    private bool  includeCancel;
    [SerializeField]
    private PopUpGen popUpGen;

    public string MessageHeader { get; set; }
    public string MessageBody { get; set; }
    public bool IncludeCancel { get; set; }

    //Call handler for generating a popUp with information in class
    public void ShowPop()
    {
        popUpGen.GeneratePopUp(this);
    }
}
