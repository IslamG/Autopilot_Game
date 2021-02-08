using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailNotification : Puzzle
{
    //public EmailNotification instance;

    [SerializeField]
    GameObject emailWindow;
    [SerializeField]
    Puzzle mailTask;

    private bool readEmail = false;


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
        //emailWindow.SetActive(true);
        readEmail = true;
        HideNotification();
        //taskMenu.RemoveTaskFromList(taskToHide);
        if (!isActive)
        {
            Activate();
            mailTask.Solve();
        }
        
        //gameObject.GetComponent<PuzzlePiece>().enabled = true;
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
