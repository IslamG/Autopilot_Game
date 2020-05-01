using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    private Text taskText;
    public bool isActive=false;
    private bool isCompleted = false;

    //Access active attribute
    public void SetActive()
    {
        isActive = true;
    }
    //Change text according to task
    private void SetText()
    {
        taskText.text = "Get into your computer";
    }
}
