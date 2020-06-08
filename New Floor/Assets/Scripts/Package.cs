using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Package : MonoBehaviour
{
    public delegate void DelegateFunc();
    DelegateFunc del;

    [SerializeField]
    PopUpGen popUpGen;
    [SerializeField]
    FirstPersonController fpc;

    private bool shown = false;
    public static bool PackageOpened { get; set; } = false;

    private void OnMouseDown()
    {
        if (!shown)
        {
            gameObject.GetComponent<PopUp>().ShowPop();
            del = AskToOpen;
            fpc.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
            popUpGen.gameObject.SetActive(true);
            shown = true;
            
        }
        
    }
    private void AskToOpen()
    {
        fpc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("!");
        if (PackageOpened)
        {
            //Do something later
            Debug.Log("Opened Package");
        }
    }
}
