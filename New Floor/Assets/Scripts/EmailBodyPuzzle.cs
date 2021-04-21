using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmailBodyPuzzle : Puzzle
{
    [SerializeField]
    TMP_Text hintText;
    [SerializeField]
    GameObject[] wordSpaces;
    [SerializeField]
    GameObject window1, window2;
    [SerializeField]
    Puzzle mailPuzzle;

    public void DisplayWordHint(GameObject clickedField)
    {
        string hint="";

        if (clickedField.name.Contains("Daughter"))
        {
            hint = "Noun 8 letters: Female offspring";
        }
        else if (clickedField.name.Contains("Diagnosis"))
        {
            hint = "Noun 8 letters: The determined cause of an illness";
        }
        else if (clickedField.name.Contains("Late"))
        {
            hint = "Adjective 4 letters: opposite of early";
        }
        else if (clickedField.name.Contains("Fees"))
        {
            hint = "Noun, plural, 4 letters: Cost of a service";
        }
        else if (clickedField.name.Contains("Release"))
        {
            hint = "Verb 8 letters: Let go";
        }
        else if (clickedField.name.Contains("Pay"))
        {
            hint = "Verb 3 letters: Hand over money";
        }
        else if (clickedField.name.Contains("Week"))
        {
            hint = "Noun 4 letters: 7 days";
        }

        hintText.text = hint;
    }
    public void CheckBlank(GameObject clickedField)
    {
        string name = clickedField.name.Replace("Input", "");
        string typedText = clickedField.GetComponent<TMP_InputField>().text;
        if (typedText.Equals(name, StringComparison.InvariantCultureIgnoreCase))
        {
            
            clickedField.SetActive(false);
        }
        CheckFinished();
        
    }
    private void CheckFinished()
    {
        int total = 0;
        foreach(GameObject field in wordSpaces)
        {
            if (field.activeSelf)
            {
                //finished = false;
                total = 0;
            }
            else
            {
                total++;
            }
        }
        if (total==wordSpaces.Length)
        {
            //Solve();
            mailPuzzle.Solve();
            if (!isActive)
            {
                Activate();
            }
        }
    }
    public void ClearHint()
    {
        hintText.text = "";
    }
    public void SwitchWindoTabs(GameObject clickedButton)
    {
        if (clickedButton.name.Contains("1"))
        {
            window1.SetActive(true);
            window2.SetActive(false);
        }
        else
        {
            window2.SetActive(true);
            window1.SetActive(false);
        }
        ClearHint();
    }
    public void DownloadAttachments()
    {
        hintText.text = "Downloaded to: PC_6//Desktop//USB";
    }
}
