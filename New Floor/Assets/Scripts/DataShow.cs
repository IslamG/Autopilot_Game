using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataShow : InteractableScreen
{
    [SerializeField]
    Button forward, back;
    [SerializeField]
    TMP_Text description;
    [SerializeField]
    Material[] collectableMats;
    [SerializeField]
    RawImage displayImage;

    int index = 0, count = 6;

    RawImage[] foundImages = new RawImage[6];
    string[] descriptions = new string[6];

    protected override void Start()
    {
        base.Start();
        Init();
        DisplayPicture();
    }
    private void Init()
    {
        descriptions[0] = " Picture of a donut";
        descriptions[1] = " Picture of a spider";
        descriptions[2] = " Picture of a box";
        descriptions[3] = " Picture of a screen";
        descriptions[4] = " Picture of a fish tank";
        descriptions[5] = " Picture of a picture";
    }

    public void Next()
    {
        index++;
        if (index > count-1)
        {
            index = 0;
        }
        DisplayPicture();
    }
    public void Previous()
    {
        index--;
        if (index < 0)
        {
            index = (count-1);
        }
        DisplayPicture();
    }
    private void DisplayPicture()
    {
        description.text = descriptions[index];
        displayImage.texture = collectableMats[index].mainTexture;
    }
}
