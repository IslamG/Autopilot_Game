using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class TipsControl : MonoBehaviour
{
    [SerializeField]
    private Image tipHolder, overlay;
    [SerializeField]
    private Sprite[] tipSprites, textureSprites;
    [SerializeField]
    private TMP_Text tipText;

    private bool tipsEnabled = true, nothingDisplayed = true;
    private Timer tipTimer;
    private Tip tip;
    private List<Tip> finishedTipList = new List<Tip>(); 
    private List<Tip> listQueue=new List<Tip>();
    

    //Return and set enabled property
    public bool TipsEnabled { get => tipsEnabled; set => tipsEnabled = value; }

    private void Start()
    {
        EventManager.AddListener(DisplayTip);
        tipTimer=gameObject.AddComponent<Timer>();
        tipTimer.Duration = 5;
    }
    private void Update()
    {
        if (tipTimer != null)
        {
            if (tipTimer.Finished && !nothingDisplayed && !PauseMenu.isPaused)
            {
                tipHolder.gameObject.SetActive(false);
                tip.WasDisplayed = true;
                finishedTipList.Add(tip);
                nothingDisplayed = true;
                listQueue.Remove(tip);
                if (listQueue.Count>0)
                {
                    DisplayTip(listQueue.First());
                }
            }
        }
    }
    //tbd more effective method of checking if used
    //utilize WasDisplayed
    public void DisplayTip(Tip tip)
    {
        bool isUsed=false;
        foreach (Tip aTip in finishedTipList)
        {
            if (aTip.ID == tip.ID)
            {
                isUsed = true;
                break;
            }
        }
        if (!isUsed)
        {
            tipHolder.gameObject.SetActive(true);
            tipText.text=tip.DisplayText;
            int index = Random.Range(0, tipSprites.Length);
            tipHolder.sprite = tipSprites[index];
            index = Random.Range(0, textureSprites.Length);
            overlay.sprite = textureSprites[index];
            tipTimer.Run();
            nothingDisplayed = false;
            this.tip = tip;
        }
        
    }
    public Tip GenerateTip(TipScript tipScript)
    {
        Tip tip = Tip.CreateInstance<Tip>();
        tip.DisplayText = tipScript.TipText;
        Debug.Log("tip: " + tipScript.TipText);
        tip.ID = tipScript.TipID;
        if(nothingDisplayed)
            DisplayTip(tip);
        else
        {
            listQueue.Add(tip);
        }
        return tip;
    }

}
