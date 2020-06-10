using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropItem : MonoBehaviour
{
    [SerializeField]
    private DropSpot targetSpot;
    [SerializeField]
    private bool isCollectable;
    //Properties of drop items and collectables
    public bool IsCollectable { get => isCollectable; }
    public OnItemFound itemFound = new OnItemFound();
    public DropSpot TargetSpot { get => targetSpot; }

    //Add as invoker of OnItemFound
    private void Start()
    {
        EventManager.AddInvoker(this);
    }
    public void AddListener(UnityAction<DropItem> handler)
    {
        itemFound.AddListener(handler);
    }
}
