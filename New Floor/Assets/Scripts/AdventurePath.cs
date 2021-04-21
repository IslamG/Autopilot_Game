using TMPro;
using UnityEngine;

public abstract class AdventurePath : MonoBehaviour
{
    public char pathType;
    public int pathEndignsNum, pathSegments;//?
    public string pathTag;
    public TMP_Text titleText;
    public Puzzle[] segments;
    public GameObject titleHolder;
    public bool attainedItem = false;

    public OnPathActivated pathActivated = new OnPathActivated();

    protected Timer displayTimer;
    protected static int currentSegment = 0;
    protected bool wasDisplayed = false;

    protected void Start()
    {
        EventManager.AddListener(PathActivated);
        Debug.Log("I am " + this.name);
        displayTimer = gameObject.AddComponent<Timer>();
        displayTimer.Duration = 3;
        //SegmentCompleted(segments[0]);
    }
    protected void Update()
    {
        if (displayTimer.Finished)
        {
            titleHolder.SetActive(false);
            wasDisplayed = true;
        }
    }
    //Action when end reached
    public abstract void EndingReacherd();
    //Action when path object aka segment completed 
    public abstract void PathObjectEarned(AdventurePath callSource, Puzzle puzzle);
    //When Path activated event invoked
    public void PathActivated(AdventurePath piece)
    {
        if (!wasDisplayed)
        {
            titleText.text = piece.pathTag + "'s Adventure";
            titleHolder.SetActive(true);
            displayTimer.Run();
        }

    }
    //Possible handler for segment complete
    //A segment is a leaf puzzle of a path
    protected void SegmentCompleted(Puzzle puzzle)
    {
        foreach (Puzzle segment in segments)
        {
            if (!segment.IsSolved)
            {
                Debug.Log("Adventure path checking segments");
                attainedItem = false;
                break;
            }
            else
            {
                attainedItem = true;
            }
            Debug.Log("Adventure path broke inside of each");
        }
        Debug.Log("Adventure path broke outide of each");
    }
    /*public void AddListener(UnityAction<AdventurePath> handler)
    {
        pathActivated.AddListener(handler);
    }*/

}
