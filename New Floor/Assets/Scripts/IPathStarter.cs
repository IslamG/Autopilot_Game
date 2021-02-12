using UnityEngine.Events;

public interface IPathStarter
{
    void AddSelfAsInvoker();
    void AddListener(UnityAction<AdventurePath> handler);
}
