using TMPro;
using UnityEngine;

public class ToDoList : MonoBehaviour
{
    [SerializeField]
    TextMeshPro itemList;
    [SerializeField]
    TaskMenu taskMenu;

    private void Start()
    {
        EventManager.AddListener(AddTask);
    }
    private void AddTask(Task task)
    {

    }
    public void RemoveTask()
    {
        Task task = taskMenu.CompletedTaskList[taskMenu.CompletedTaskList.Count - 1];
        itemList.text += "<s>" + task.TaskText + "</s><br>";

    }
}
