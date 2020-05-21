using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TipsControl : MonoBehaviour
{
    [SerializeField]
    private Image tipHolder;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private TMP_Text tipText;

    private bool tipsEnabled = true;
    private Timer tipTimer;
    private Tip tip;
    private List<Tip> finishedTipList = new List<Tip>();

    //Return and set enabled property
    public bool TipsEnabled { get => tipsEnabled; set => tipsEnabled = value; }

    private void Start()
    {
        EventManager.AddListener(GenerateTip);
        tipTimer=gameObject.AddComponent<Timer>();
        tipTimer.Duration = 5;
    }
    //tbd manage several tips triggered near the same time
    private void Update()
    {
        if (tipTimer != null)
        {
            if (tipTimer.Finished)
                {
                    tipHolder.gameObject.SetActive(false);
                    tip.WasDisplayed = true;
                    finishedTipList.Add(tip);
                }
        }
    }
    //tbd more effective method of checking if used
    //utilize WasDisplayed
    public void GenerateTip(Tip tip)
    {
        bool isUsed=false;
        foreach(Tip aTip in finishedTipList)
        {
            if (aTip.ID == tip.ID)
            {
                isUsed = true;
            }
        }
        if (!isUsed)
        {
            tipHolder.gameObject.SetActive(true);
            tipText.text=tip.DisplayText;
            int index = Random.Range(0, sprites.Length);
            tipHolder.sprite = sprites[index];
            tipTimer.Run();
            this.tip = tip;
        }
    }

}
