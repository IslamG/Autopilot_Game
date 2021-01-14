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
    //[SerializeField]
    //Animation animationImg;

    private bool wasDisplayed = false;
    //Use to set and access tip scriptable object
    public string TipText { get=>tipText; }
    public int TipID { get=>tipID; }
    public bool WasDisplayed { get; set; }
    //public Animation AnimationImg { get => animationImg; }

}
