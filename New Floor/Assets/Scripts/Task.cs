using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    private bool isCompleted = false, notAdded=true;
    private AddTaskEvent addTaskEvent= new AddTaskEvent();

    //Get Set some properties
    public bool IsActive { get; set; } = false;
    public string TaskText { get; set; }

    private void Start()
    {
        EventManager.AddTaskInvoker(this);
    }
    //tbd replace with event call
    public void AddListener(UnityAction<Task> handler)
    {
        addTaskEvent.AddListener(handler);
    }
    //tbd set text dynamically 
    public void TaskAdd()
    {
        addTaskEvent.Invoke(this);
        Debug.Log(TaskText);
    }
}
