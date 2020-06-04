using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private string message;
    [SerializeField]
    private bool  includeCancel;
    [SerializeField]
    private PopUpGen popUpGen;

    //private PopUpStruct[] buttons;
    public string Message { get=>message;}
    public bool IncludeCancel { get => includeCancel; }
    //public PopUpStruct[] Buttons { get=>buttons;}

    private void Start()
    {
        Debug.Log("pop start");
        /*buttons = new PopUpStruct[btnCount];
        for(int i=0; i<btnCount; i++)
        {
            PopUpStruct _button = new PopUpStruct("Confirm");
            buttons[0] = _button;
        }
        Debug.Log("mess " + this.Message);*/
        popUpGen.GeneratePopUp(this);
    }
 /*   public class PopUpStruct
    {
        private string btnType;
        public string Type { get => btnType; }
        public PopUpStruct(string type)
        {
            btnType = type;
        }
    }*/
}
