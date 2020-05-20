using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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

    public bool TipsEnabled { get => tipsEnabled; set => tipsEnabled = value; }

    private void Start()
    {
        EventManager.AddListener(GenerateTip);
        tipTimer=gameObject.AddComponent<Timer>();
        tipTimer.Duration = 5;
        //GenerateTip(tip);
    }
    private void Update()
    {
        if (tipTimer != null)
        {
            if (tipTimer.Finished)
                {
                    tipHolder.gameObject.SetActive(false);
                    tip.WasDisplayed = true;
                }
        }
        
    }
    public void GenerateTip(Tip tip)
    {
        if (!tip.WasDisplayed)
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
