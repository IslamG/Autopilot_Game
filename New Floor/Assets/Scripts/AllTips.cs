using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTips: MonoBehaviour
{
    //TBD migrated to seperate tips
    [SerializeField]
    TipsControl tipsControl;

    private string menuTip, pickUp, disableTips, returnScreen;
    private int menuId=1, pickUpId=2, disableId=3, returnId=4;

    //Porperties for specific tips
    public string MenuTip { get => menuTip;}
    public string PickUp { get => pickUp;}
    public string DisableTips { get => disableTips;}
    public string ReturnScreen { get => returnScreen;}
    public int MenuId { get => menuId;}
    public int PickUpId { get => pickUpId;}
    public int DisableId { get => disableId;}
    public int ReturnId { get => returnId;}

    //Initiate values of game tips
    //tbd switch hardcoded buttons to input axis
    private void Start()
    {
        disableTips = "Tips can be disabled from the options menu";
        menuTip= "Click M to bring up your task menu";// " + Input.GetAxis("Menu") + "
        pickUp = "Click and hold LMB to grab an interactable object";
        returnScreen = "Use BACKSPACE to switch back camera";
    }
}
