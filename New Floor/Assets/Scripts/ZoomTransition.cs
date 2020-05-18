using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomTransition : MonoBehaviour
{
    private MainMenu menu;
    /*[SerializeField]
    private RectTransform panelRect;
    [SerializeField]
    RectTransform rect;
    Rect menuRect;
    float panelHeight, panelWidth, menuHeight, menuWidth;
    Vector3 menuCenter, panelCenter;*/
    void Start()
    {
        //tbd add slerp to smooth animation
        menu = transform.parent.GetComponentInChildren<MainMenu>();
        /*
        menuRect = rect.rect;
        panelHeight = panelRect.sizeDelta.y;
        panelWidth = panelRect.sizeDelta.x;
        menuHeight = menuRect.height;
        menuWidth = menuRect.width;
        panelCenter = panelRect.localPosition;
        menuCenter = menuRect.center;*/
    }
    public void Switch()
    {
        menu.SwitchScene();
        //MoveToCenter();
    }
    //Possible alternative scripted animation
    /*public void MoveToCenter()
    {
        float ratioH = Screen.width / panelWidth;
        float ratioW = Screen.height / panelHeight;
        menuRect.width=  menuWidth* ratioW;
        menuRect.height=  menuHeight* ratioH;
        rect.sizeDelta = new Vector2(menuRect.width, menuRect.height);
        Debug.Log("Panel H: " + panelHeight + " Panel W: " + panelWidth);
        Debug.Log("Ratio h: " + ratioH+" ratio w: "+ratioW);
        Debug.Log("menu H: " + (menuHeight*ratioH) + 
            " menu W: " + (menuWidth*ratioW));
    }*/
}
