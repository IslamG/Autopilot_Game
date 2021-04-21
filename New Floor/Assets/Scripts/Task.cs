using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    [SerializeField]
    private string taskText, taskDescription;
    [SerializeField]
    private char taskGroup;

    private TaskOnBecameActive taskActivated = new TaskOnBecameActive();
    private bool isActive = false;
    //property for returning text, used for menu
    public string TaskText { get => taskText; }
    public string TaskDescription { get => taskDescription; }
    public bool IsRegistered { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsActive { get=> isActive; }
    public char TaskGroup { get => taskGroup; }

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
        if (!IsCompleted && !IsRegistered)
        {
            taskActivated.Invoke(this);
            isActive = true;
        }
            
    }
    public void Deactivate()
    {
        isActive = false;
    }
}
