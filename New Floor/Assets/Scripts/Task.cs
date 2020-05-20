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
        Debug.Log("Call to add as invoker");
        EventManager.AddInvoker(this);
    }
    public void AddListener(UnityAction<Task> handler)
    {
        Debug.Log("Registering event on Task");
        taskActivated.AddListener(handler);
    }
    public void ActivateTask()
    {
        Debug.Log("Invoke call");
        taskActivated.Invoke(this);
    }
}
