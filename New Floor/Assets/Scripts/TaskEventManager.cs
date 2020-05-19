using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//tbd make generic ?
public static class TaskEventManager
{
    //tbd rethink invoker type
    static List<Task> taskInvokers = new List<Task>();
    //tbd change delegate params as needed
    static List<UnityAction<Task>> taskListeners = new List<UnityAction<Task>>();

    //to add dynamically
    //tbd rethink if needed
    public static void AddTaskInvoker(Task taskInvoker)
    {
        //add new puzzle to list
        //then add a listener to the puzzle
        taskInvokers.Add(taskInvoker);
        foreach (UnityAction<Task> listener in taskListeners)
        {
            taskInvoker.AddListener(listener);
            Debug.Log("Listener: " + listener);
        }
    }
    public static void AddTaskListener(UnityAction<Task> handler)
    {
        taskListeners.Add(handler);
        foreach (Task task in taskInvokers)
        {
           task.AddListener(handler);
            Debug.Log("Invoker: " + handler);
        }
    }
}