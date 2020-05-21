using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTips: MonoBehaviour
{
    [SerializeField]
    TipsControl tipsControl;

    private string menuTip, pickUp, disableTips, returnScreen;

    //Porperties for specific tips
    public string MenuTip { get => menuTip;}
    public string PickUp { get => pickUp;}
    public string DisableTips { get => disableTips;}
    public string ReturnScreen { get => returnScreen;}

    //Initiate values of game tips
    //tbd switch hardcoded buttons to input axis
    private void Start()
    {
        disableTips = "Tips can be disabled from the options menu";
        menuTip= "Click M to bring up your task menu";// " + Input.GetAxis("Menu") + "
        pickUp = "Click and hold LMB to grab an interactable object";
        returnScreen = "Use BACKSPACE to switch back camera";
    }
    //tbd find appropriate place to trigger tip generation
    private void OnMouseDown()
    {
        Tip tip = Tip.CreateInstance<Tip>();
        tip.DisplayText = ReturnScreen;
        tip.ID = 1;
        tipsControl.GenerateTip(tip);
    }
}
