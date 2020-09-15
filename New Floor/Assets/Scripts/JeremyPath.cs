using UnityEngine;

public class JeremyPath : AdventurePath
{
    public static JeremyPath instance;
    void Awake()
    {
        if (instance == null)
            instance = this;

    }
    public override void EndingReacherd()
    {
        throw new System.NotImplementedException();
    }

    public override void PathObjectConsumed()
    {
        throw new System.NotImplementedException();
    }
}
