using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<Task> taskInvokers = new List<Task>();
    static List<UnityAction<Task>> taskListeners = new List<UnityAction<Task>>();
    
    //tbd figureout haulmark invokers
    static List<Tip> haulmarkInvokers = new List<Tip>();
    static List<UnityAction<Tip>> haulmarkListeners = new List<UnityAction<Tip>>();

    public static void AddInvoker(Task taskInvoker)
    {
        //add new puzzle to list
        //then add a listener to the puzzle
        taskInvokers.Add(taskInvoker);
        foreach (UnityAction<Task> listener in taskListeners)
        {
            taskInvoker.AddListener(listener);
        }
    }
    public static void AddListener(UnityAction<Task> handler)
    {
        taskListeners.Add(handler);
        foreach (Task task in taskInvokers)
        {
           task.AddListener(handler);
        }
    }
    //Haulmark overload
    public static void AddInvoker(Tip haulmarkInvoker)
    {
        //add new tip to list
        //then add a listener to the tip
        haulmarkInvokers.Add(haulmarkInvoker);
        foreach (UnityAction<Tip> listener in haulmarkListeners)
        {
            haulmarkInvoker.AddListener(listener);
        }
    }
    public static void AddListener(UnityAction<Tip> handler)
    {
        haulmarkListeners.Add(handler);
        foreach (Tip tip in haulmarkInvokers)
        {
            tip.AddListener(handler);
        }
    }

}