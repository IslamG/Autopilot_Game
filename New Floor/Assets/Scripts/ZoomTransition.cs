using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class to manually control zoom in on screen transition
//tbd remove probably
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
    /*public void Transition()
    {
        Vector2 screenCenter = new Vector2(Screen.width, Screen.height);
        //RectTransform bTrans = background.gameObject.GetComponent<RectTransform>();
        //Rect mRect = rect.gameObject.GetComponent<RectTransform>().rect;
        //Rect bRect = bTrans.rect;
        //Rect mRect = new Rect(rect.pivot, 
        //    new Vector2(rect.sizeDelta.x, rect.sizeDelta.y));
        Vector2 mRect = rect_Panel.sizeDelta;
        Vector2 bRect = bTrans.sizeDelta;
        Debug.Log("rect: " + mRect + " " + bRect);
        /*float widthRatio = bRect.x / mRect.x;
        float heightRatio = bRect.y / mRect.y;
        float centerRatioX = (bRect.x / 2) / (mRect.x/2);
        float centerRatioY = (bRect.y / 2) / (mRect.y/2);
        bTrans.sizeDelta = new Vector2(bRect.x * widthRatio, 
            bRect.y * heightRatio);
        bTrans.position = new Vector2((bRect.x/2)*centerRatioX,
            (bRect.y / 2) * centerRatioY);
        background.transform.localScale = background.transform.localScale * 5f;
    }*/
}
