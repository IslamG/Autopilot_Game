using UnityEngine.Events;

public class PathStarter : Puzzle, IPathStarter
{
    public OnPathActivated pathActivated = new OnPathActivated();

    protected override void Start()
    {
        base.Start();
        AddSelfAsInvoker();
    }
    public void AddListener(UnityAction<AdventurePath> handler)
    {
        pathActivated.AddListener(handler);
    }

    public void AddSelfAsInvoker()
    {
        EventManager.AddInvoker(this);
    }
}
