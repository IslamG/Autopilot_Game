using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoryControl : MonoBehaviour
{
    [SerializeField]
    Animator panelAnimator;
    [SerializeField]
    Button prevButton;
    [SerializeField]
    Image thoughtHolder, mainImage;
    [SerializeField]
    TMP_Text narration;

    private int panelNum=1;

    private void Start()
    {
        Check();
        panelNum = panelAnimator.GetInteger("PanelNum");
    }
    //private void Awake()
    //{
    //    Application.targetFrameRate = 60; 
    //}
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        Application.Quit();
    //    }
    //}
    public void NextPanel()
    {
        panelNum++;
        Check();
        panelAnimator.SetInteger("PanelNum", panelNum);
    }
    public void PreviousPaenl()
    {
        panelNum--;
        Check();
        panelAnimator.SetInteger("PanelNum", panelNum);
    }
    private void Check()
    {
        if (panelNum == 1)
        {
            prevButton.gameObject.SetActive(false);
        }
        else
        {
            prevButton.gameObject.SetActive(true);
        }
        if (panelNum == 2 || panelNum == 4)
        {
            thoughtHolder.gameObject.SetActive(true);
            thoughtHolder.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            thoughtHolder.gameObject.SetActive(false);
        }
        if (panelNum == 4)
        {
            thoughtHolder.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (panelNum == 6)
        {
            mainImage.sprite = null;
        }
        switch (panelNum)
        {
            case 1:
                {
                    narration.text = "Grey is a regular guy bored at his mundane job every day.";
                    break;
                }
            case 2:
                {
                    narration.text = "To escape boredom he Imagines himself in heroic adventures.";
                    break;
                }
            case 3:
                {
                    narration.text = "To a world where's he's completely alone and free to do what he wants.";
                    break;
                }
            case 5:
                {
                    narration.text = "until he has to snap back into reality.";
                    break;
                }
            case 6:
                {
                    narration.text = "One day...";
                    break;
                }
            default:
                {
                    narration.text = "";
                    break;
                }
        }
    }
}
