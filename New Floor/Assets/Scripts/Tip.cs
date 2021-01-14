using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Tip", menuName = "Tip", order = 51)]
public class Tip : ScriptableObject
{
    OnHaulmarkReachedEvent haulmarkReached = new OnHaulmarkReachedEvent();
    //Returning and setting main properties of tips
    //possibly trim down
    public Sprite TipSprite { get; set; } 
    public string DisplayText { get; set; }
    public bool WasDisplayed { get; set; }
    public int ID { get; set; }
    //public Animation AnimationImg { get; set; }

    //Add as invoker of OnHaulmarkReached
    private void Start()
    {
        EventManager.AddInvoker(this);
    }
    public void AddListener(UnityAction<Tip> handler)
    {
        haulmarkReached.AddListener(handler);
    }
    public void GenerateTip()
    {
        haulmarkReached.Invoke(this);
    }
}
