using System;
using System.Collections;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public const float totalTime = 360;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    //Singleton class
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        timerGoing = false;
    }
    //Start tracking time
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0;

        StartCoroutine(UpdateTimer());
    }
    //Stop timer
    public void EndTimer()
    {
        timerGoing = false;
    }
    //Increment timer, keeping track of time
    //tbd use this value to end game
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");

            yield return null;
        }
    }
}
