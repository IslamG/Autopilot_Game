using System.Collections.Generic;
using UnityEngine;

public class JeremyPath : AdventurePath
{
    public static JeremyPath instance;
    [SerializeField]
    Dictionary<AdventurePath, GameObject> finalItems;

    void Awake()
    {
        if (instance == null)
            instance = this;

    }
    public override void EndingReacherd()
    {
        
    }

    public override void PathObjectEarned(AdventurePath callSource, Puzzle puzzle)
    {
        SegmentCompleted(puzzle);
        if (callSource.attainedItem)
        {
            Debug.Log("Jeremy Path do a thing");
        }
    }
}
