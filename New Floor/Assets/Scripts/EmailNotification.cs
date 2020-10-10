using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailNotification : Puzzle
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
        //gameObject.GetComponent<PuzzlePiece>().enabled = true;
    }
    private void Awake()
    {
        Activate();
    }
    protected override void Activate()
    {
        //Activate task based on attached task 
        isActive = true;
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();
    }
}
