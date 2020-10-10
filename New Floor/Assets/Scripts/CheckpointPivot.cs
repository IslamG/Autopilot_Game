using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointPivot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text helperText;
    [SerializeField]
    private string[] dialogueParts;

    Timer timer;
    bool showingHelper = false, showed=false;
    int i = 0;

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
    }
    private void Update()
    {
        //Switch between text parts
        if (showingHelper)
        {   //When part displayed for set amount of time
            if (timer.Finished && i<dialogueParts.Length)
            {
                StartHintDisplay();   
                i++;
            }//When all parts done displaying
            else if (timer.Finished && i >= dialogueParts.Length)
            {
                helperText.text = "";
                helperText.faceColor = Color.white;
                showingHelper = false;
                //this.gameObject.SetActive(false);
            }
        }
    }
    private void OnMouseDown()
    {
        StartHintDisplay();
    }
    private void StartHintDisplay()
    {
        //If text hasn't been shown before, show hint and hide post
        if (!showed)
        {
            //Show text and start timer for switching parts
            if (helperText != null)
            {
                showed = true;
                Debug.Log("."+dialogueParts[i].ToString());
                helperText.text = dialogueParts[i];
                timer.Run();
                showingHelper = true;
                //tbd different highlight for different tasks
                if (i == dialogueParts.Length-1)
                {
                    helperText.faceColor = Color.cyan;
                    //helperText.outlineWidth = 0.25f;
                }
            }
        }
    }
}
