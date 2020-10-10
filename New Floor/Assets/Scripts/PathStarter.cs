using UnityEngine;
using UnityEngine.Events;

public abstract class PathStarter : Puzzle
{
    [SerializeField]
    protected GameObject arrow;

    public OnPathActivated pathActivated = new OnPathActivated();

    protected void Start()
    {
        EventManager.AddInvoker(this);
    }
    public void AddListener(UnityAction<AdventurePath> handler)
    {
        pathActivated.AddListener(handler);
    }
}
