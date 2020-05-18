using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private TaskMenu taskMenu;
    private static List<Task> taskList=new List<Task>();

    private void Start()
    {
        //Task task=gameObject.AddComponent<Task>();
        //AddSelf(task);
        EventManager.AddQuestListener(AddNewTask);
    }
    private void AddNewTask()
    {
        //taskList.Add(newTask);
        Debug.Log("New Task Added");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            foreach(Task _task in taskList)
            {
                if (_task.IsActive)
                {
                    Debug.Log("Task: " + _task + " List: " + taskList);
                    //Task aTask = _task;
                    taskMenu.AddTask(_task);
                    taskList = taskList.Distinct().ToList();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Task aTask = gameObject.AddComponent<Task>();
            //Instantiate<Task>(aTask);
            aTask.IsActive = true;
        }
    }
}
