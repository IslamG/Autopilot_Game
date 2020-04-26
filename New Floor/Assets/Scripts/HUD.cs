using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    float elapsedTime = 0;
    bool timerRunning = true;

    private void Start()
    {
        timeText.text = "0";
        elapsedTime = 0;
    }
    private void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            timeText.text = ((int)elapsedTime).ToString();
        }
    }
    public void StopTimer()
    {
        timerRunning = false;
    }
}
