using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//tbd make generic ?
public static class EventManager
{
    //tbd rethink invoker type
    static List<QuestTrigger> questInvokers = new List<QuestTrigger>();
    //tbd change delegate params as needed
    static List<UnityAction> questListeners = new List<UnityAction>();

    static List<Task> taskInvokers = new List<Task>();
    static List<UnityAction<Task>> taskListeners = new List<UnityAction<Task>>();

    //to add dynamically
    //tbd rethink if needed
    public static void AddQuestInvoker(QuestTrigger questInvoker)
    {
        //add new puzzle to list
        //then add a listener to the puzzle
        questInvokers.Add(questInvoker);
        foreach(UnityAction listener in questListeners)
        {
           questInvoker.AddListener(listener);
        }
    }
    public static void AddQuestListener(UnityAction handler)
    {
        questListeners.Add(handler);
        foreach (QuestTrigger quest in questInvokers)
        {
            quest.AddListener(handler);
        }
    }

    public static void AddTaskInvoker(Task taskInvoker)
    {
        //add new puzzle to list
        //then add a listener to the puzzle
        taskInvokers.Add(taskInvoker);
        foreach (UnityAction<Task> listener in taskListeners)
        {
            taskInvoker.AddListener(listener);
        }
    }
    public static void AddTaskListener(UnityAction<Task> handler)
    {
        taskListeners.Add(handler);
        foreach (Task task in taskInvokers)
        {
            task.AddListener(handler);
        }
    }
}