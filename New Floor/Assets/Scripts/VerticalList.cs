﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalList : VerticalLayoutGroup
{
    public override void CalculateLayoutInputVertical()
    {
        base.CalculateLayoutInputVertical();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, minHeight);
    }

}
