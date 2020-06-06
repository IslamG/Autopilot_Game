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

    public void ShowPop()
    {
        Debug.Log("pop start");
        popUpGen.GeneratePopUp(this);
    }
}
