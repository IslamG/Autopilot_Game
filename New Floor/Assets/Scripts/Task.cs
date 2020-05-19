using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    //private bool isCompleted = false, notAdded=true;
    private TaskOnBecameActive taskActivated = new TaskOnBecameActive();
    //Get Set some properties
    [SerializeField]
    private string taskText;
    public string TaskText { get => taskText;}

    private void Start()
    {
        TaskEventManager.AddTaskInvoker(this);
    }
    //tbd replace with event call
    public void AddListener(UnityAction<Task> handler)
    {
        taskActivated.AddListener(handler);
    }
    public void ActivateTask()
    {
        Debug.Log("Invoke call");
        taskActivated.Invoke(this);
    }
}
