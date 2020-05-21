using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    [SerializeField]
    private string taskText;

    //private bool isCompleted = false, notAdded=true;
    private TaskOnBecameActive taskActivated = new TaskOnBecameActive();

    //property for returning text, used for menu
    public string TaskText { get => taskText;}
    //Add as invoker of OnBecameActive
    private void Start()
    {
        EventManager.AddInvoker(this);
    }
    public void AddListener(UnityAction<Task> handler)
    {
        taskActivated.AddListener(handler);
    }
    public void ActivateTask()
    {
        taskActivated.Invoke(this);
    }
}
