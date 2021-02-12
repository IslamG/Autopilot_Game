using UnityEngine;

public class DelayedClock : Puzzle
{
    [SerializeField]
    AheadClock aheadClock;

    private float minutes, hours;

    public float Minutes { get => minutes; set => minutes = value; }
    public float Hours { get => hours; set => hours = value; }

    public void Delay()
    {
        minutes = aheadClock.Minutes + 30;
        hours = aheadClock.Hours + (30 * 2);

        gameObject.GetComponent<ClockFace>().SetNewTime(minutes, hours);
    }
}
