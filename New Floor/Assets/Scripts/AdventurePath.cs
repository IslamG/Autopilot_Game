using TMPro;
using UnityEngine;

public abstract class AdventurePath : MonoBehaviour
{
    public char pathType;
    public int pathEndignsNum, pathSegments;
    public string pathTag;
    public TMP_Text titleText;
    public GameObject[] segments;
    public GameObject titleHolder;

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
    public abstract void PathObjectConsumed();
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
    /*public void AddListener(UnityAction<AdventurePath> handler)
    {
        pathActivated.AddListener(handler);
    }*/

}
