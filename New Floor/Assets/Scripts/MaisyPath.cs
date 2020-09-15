using UnityEngine;

public class MaisyPath : AdventurePath
{
    public static MaisyPath instance;
    
    public override void EndingReacherd()
    {
        throw new System.NotImplementedException();
    }

    public override void PathObjectConsumed()
    {
        currentSegment += 1;
        Debug.Log("Current in " + this.name + " " + currentSegment);
    }
}
