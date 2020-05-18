using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestTrigger : MonoBehaviour
{
    private QuestStartEvent questStartEvent = new QuestStartEvent();
    private bool isAdded = false;
    private void Start()
    {
        EventManager.AddQuestInvoker(this);
    }
    void OnMouseDown()
    {
        if (!isAdded)
        {
            questStartEvent.Invoke();
            Debug.Log("Something's happening");
            isAdded = true;
            Task task = gameObject.GetComponent<Task>();
            task.TaskText = "Return package to Maisy";
            task.IsActive = true;
            task.TaskAdd();
        }
        
    }
    public void AddListener(UnityAction handler)
    {
        questStartEvent.AddListener(handler);
    }
}
