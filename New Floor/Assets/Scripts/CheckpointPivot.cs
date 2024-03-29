﻿using TMPro;
using UnityEngine;

public class CheckpointPivot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text helperText;
    [SerializeField]
    private string[] dialogueParts;
    [SerializeField]
    BasicTutorial manager;
    Timer timer;
    bool showingHelper = false, showed = false;
    int i = 0;

    private void Awake()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 4;
    }
    private void Update()
    {
        //Switch between text parts
        if (showingHelper)
        {   //When part displayed for set amount of time
            if (timer.Finished && i < dialogueParts.Length)
            {
                DisplaySequence();
                i++;
                Debug.Log("Checkpoint update time finished 1");
            }//When all parts done displaying
            else if (timer.Finished && i >= dialogueParts.Length)
            {
                helperText.text = "";
                helperText.faceColor = Color.white;
                showingHelper = false;
                //this.gameObject.SetActive(false);
                Debug.Log("Checkpoint update time finished 2");
            }
        }
    }
    public void StartHintDisplay()
    {
        DisplaySequence();
        showingHelper = true;
    }
    private void DisplaySequence()
    {
        //If text hasn't been shown before, show hint and hide post
        //if (!showed)
        //{
        //Show text and start timer for switching parts
        if (helperText != null)
        {
            //showed = true;
            Debug.Log("." + dialogueParts[i].ToString());
            helperText.text = dialogueParts[i];
            timer.Run();
            //tbd different highlight for different tasks
            if (i == dialogueParts.Length - 1)
            {
                //helperText.faceColor = Color.cyan;
                //helperText.outlineWidth = 0.25f;
                if (manager != null)
                    manager.InputEnabled = true;
            }
            // }
        }
    }
}
