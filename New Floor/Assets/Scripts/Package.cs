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

    //When a package is clicked, show pop up prompting to open
    private void OnMouseDown()
    {
        //If pop up hasn't been shown before
        if (!shown)
        {
            //Show pop up, disable movement, and show cursor
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
    //Method to redirect to when decision made in pop up
    private void AskToOpen()
    {
        //Allow movement, hide cursor, and trigger decision consequences
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
