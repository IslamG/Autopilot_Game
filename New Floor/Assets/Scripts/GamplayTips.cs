using TMPro;
using UnityEngine;

public class GamplayTips : MonoBehaviour
{
    [SerializeField]
    TMP_Text txt;
    string autoSaveTip, menuTip, timeTip;
    string[] tips;

    //initialize available tips
    //tbd populate dynamically
    void Start()
    {
        autoSaveTip = "The Game Autosaves when progress is made";
        menuTip = "View your objectives by pressing M";
        timeTip = "Your shift ends at 5PM";
        tips = new string[3];
        tips[0] = autoSaveTip;
        tips[1] = menuTip;
        tips[2] = timeTip;
        SelectTip();

    }
    //Select a top to be displayed
    //tbd make weighted priority
    void SelectTip()
    {
        int index = Random.Range(0, tips.Length);
        txt.text = tips[index];
        //tbd cycle through tips over time
    }
}
