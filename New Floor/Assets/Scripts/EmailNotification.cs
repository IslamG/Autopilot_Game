using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailNotification : MonoBehaviour
{
    [SerializeField]
    GameObject emailWindow;

    private bool readEmail=false;


    public void HideNotification()
    {
        gameObject.SetActive(false);
        if (!readEmail)
        {
            //Show notification in tray
        }
    }
    public void ShowMailWindow()
    {
        emailWindow.SetActive(true);
        readEmail = true;
        HideNotification();
    }

}
