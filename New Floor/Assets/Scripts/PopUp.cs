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

    public string MessageHeader { get=>messageHeader;}
    public string MessageBody { get=>messageBody;}
    public bool IncludeCancel { get => includeCancel; }

    //Call handler for generating a popUp with information in class
    public void ShowPop()
    {
        popUpGen.GeneratePopUp(this);
    }
}
