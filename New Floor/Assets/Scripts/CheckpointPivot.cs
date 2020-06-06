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
        //s1 = "This is Jeremy's desk, nice guy, too bad we never talk";
        //s2 = "Too bad, I wish I knew more about him.";
        //s3 = "He probably would've helped me.";
         
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
    }
    private void Update()
    {
        if (showingHelper)
        {
            if (timer.Finished && i<dialogueParts.Length)
            {
                StartHintDisplay();   
                i++;
            }
            else if (timer.Finished && i >= dialogueParts.Length)
            {
                helperText.text = "";
                helperText.faceColor = Color.white;
                showingHelper = false;
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!showed)
            {
                StartHintDisplay();
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
                
        }
    }
    private void StartHintDisplay()
    {
        if (helperText != null)
        {
            showed = true;
            Debug.Log("."+dialogueParts[i].ToString());
            helperText.text = dialogueParts[i];
            timer.Run();
            showingHelper = true;
            if (i == dialogueParts.Length-1)
            {
                helperText.faceColor = Color.cyan;
                //helperText.outlineWidth = 0.25f;
            }
        }    
    }
}
