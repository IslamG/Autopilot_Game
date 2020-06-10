using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AheadClock : MonoBehaviour
{
    [SerializeField]
    DelayedClock delayedClock;

    private float minutes, hours;

    public float Minutes { get => minutes; set => minutes = value; }
    public float Hours { get => hours; set => hours = value; }

    public void Forward()
    {
        
        minutes = delayedClock.Minutes - 30;
        hours = delayedClock.Hours - (30 * 2);

        gameObject.GetComponent<ClockFace>().SetNewTime(minutes, hours);
    }
}
