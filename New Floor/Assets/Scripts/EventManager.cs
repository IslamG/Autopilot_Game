using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    static List<Task> taskInvokers = new List<Task>();
    static List<UnityAction<Task>> taskListeners = new List<UnityAction<Task>>();

    //tbd figureout haulmark invokers
    static List<Tip> haulmarkInvokers = new List<Tip>();
    static List<UnityAction<Tip>> haulmarkListeners = new List<UnityAction<Tip>>();

    static List<DropItem> foundInvokers = new List<DropItem>();
    static List<UnityAction<DropItem>> foundListeners = new List<UnityAction<DropItem>>();

    static List<PathStarter> puzzleInvokers = new List<PathStarter>();
    //static List<AdventurePath> pathInvokers = new List<AdventurePath>();
    //static List<UnityAction<AdventurePath>> pathListeners = new List<UnityAction<AdventurePath>>();
    static List<UnityAction<AdventurePath>> puzzleListeners = new List<UnityAction<AdventurePath>>();

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
        foreach (Tip path in haulmarkInvokers)
        {
            path.AddListener(handler);
        }
    }

    //FoundItem overload
    public static void AddInvoker(DropItem item)
    {
        //add new tip to list
        //then add a listener to the tip
        foundInvokers.Add(item);
        foreach (UnityAction<DropItem> listener in foundListeners)
        {
            item.AddListener(listener);
        }
    }
    public static void AddListener(UnityAction<DropItem> handler)
    {
        foundListeners.Add(handler);
        foreach (DropItem item in foundInvokers)
        {
            item.AddListener(handler);
        }
    }

    //PathActivated overload
    public static void AddInvoker(PathStarter puzzleInvoker)
    {
        //add new puzzle to list
        //then add a listener to the puzzle
        puzzleInvokers.Add(puzzleInvoker);
        foreach (UnityAction<AdventurePath> listener in puzzleListeners)
        {
            puzzleInvoker.AddListener(listener);
        }
    }
    /*public static void AddInvoker(AdventurePath path)
    {
        //add new puzzle to list
        //then add a listener to the puzzle
        pathInvokers.Add(path);
        foreach (UnityAction<AdventurePath> listener in pathListeners)
        {
            pathInvoker.AddListener(listener);
        }
    }*/
    public static void AddListener(UnityAction<AdventurePath> handler)
    {
        puzzleListeners.Add(handler);
        /*foreach (AdventurePath piece in puzzleInvokers)
        {
            piece.AddListener(handler);
        }*/
        foreach (PathStarter piece in puzzleInvokers)
        {
            piece.AddListener(handler);
        }
    }
}