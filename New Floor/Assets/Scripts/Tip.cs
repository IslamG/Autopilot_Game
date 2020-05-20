using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Tip", menuName = "Tip", order = 51)]
public class Tip : ScriptableObject
{
    OnHaulmarkReachedEvent haulmarkReached = new OnHaulmarkReachedEvent();
    public Sprite TipSprite { get; set; } 
    public string DisplayText { get; set; }
    public bool WasDisplayed { get; set; }
    private void Start()
    {
        Debug.Log("Call to add as invoker");
        EventManager.AddInvoker(this);
    }
    public void AddListener(UnityAction<Tip> handler)
    {
        Debug.Log("Registering event on Task");
        haulmarkReached.AddListener(handler);
    }
    public void GenerateTask()
    {
        Debug.Log("Invoke call");
        haulmarkReached.Invoke(this);
    }
}
