using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraConeEntered : MonoBehaviour
{
    [SerializeField]
    RawImage timerImg;
    [SerializeField]
    Button selfButton;

    Timer timer;
    SecutiryPuzzle securityPuzzle;
    bool ran = false;

    public RawImage TimerImg { get => timerImg;  }
    public Button SelfButton { get => selfButton; }
    public bool Ran { get => ran; set => ran = value; }

    TMP_Text countDown;

    int total = 5; 

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5;
        securityPuzzle=gameObject.GetComponentInParent<SecutiryPuzzle>();
        countDown = timerImg.GetComponentInChildren<TMP_Text>();
    }
    private void Update()
    {
        if (timer.Running)
        {
            countDown.text = timer.ElapsedSeconds.ToString(); 
        }
        if (timer.Finished && ran)
        {
            securityPuzzle.HideCones(gameObject.transform.GetChild(0).gameObject);
            //selfButton.interactable = false;
            ran = false;
            Debug.Log("CCE update timer finished called");
        }
    }
}
