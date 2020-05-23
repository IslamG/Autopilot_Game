using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    [SerializeField]
    string tipText;
    [SerializeField]
    int tipID;
    [SerializeField]
    TipsControl tipControl;

    private bool wasDisplayed = false;

    public string TipText { get=>tipText; }
    public int TipID { get=>tipID; }
    public bool WasDisplayed { get; set; }

}
