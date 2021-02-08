using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseIndicator : MonoBehaviour
{
    [SerializeField]
    Sprite defaultMouse, focusMouse, clickMouse, lmb, rmb,
        handOpen, handClosed, lookAt, lookCloser;
    [SerializeField]
    private float reach;
    [SerializeField]
    Image crosshair;
    Animator crosshairAnimator;
    Camera viewCamera;
    private Transform _selection;
    private bool isFocused = false, itemHeld=false;


    private void Start()
    {
        viewCamera = gameObject.GetComponent<Camera>();
        crosshairAnimator = crosshair.GetComponent<Animator>();
    }
    private void Update()
    {
        //If not currently over any special object
        if (_selection != null && !itemHeld)
        {
            crosshair.sprite = focusMouse;
            Unfocus();
        }
        //Change icon normally if mosue isn't held down
        if (!itemHeld)
        {
            SetCursor();
        }
        //If mouse held down change cursor to hold icon
        else
        {
            if (!(Input.GetAxis("Use") > 0))
            {
                itemHeld = false;
                SetCursor();
            }
        }  
    }
    private void SetCursor()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reach))
        {
            //If hovering over special object, use correct mouse icon
            GameObject selection = hit.transform.gameObject;
            if (selection.CompareTag("Selectable"))
            {
                crosshair.sprite = handOpen;
                if (Input.GetMouseButton(0))
                {
                    crosshair.sprite = handClosed;
                    itemHeld = true;
                }
                _selection = selection.transform;
            }
            else if (selection.CompareTag("Clickable"))
            {
                crosshair.sprite = clickMouse;
                //crosshairAnimator.Play("LMB_Click");
                if (Input.GetMouseButton(0))
                    crosshair.sprite = lmb;
                if (Input.GetMouseButton(1))
                    crosshair.sprite = rmb;
                _selection = selection.transform;
            }
            else if (selection.CompareTag("Viewable"))
            {
                crosshair.sprite = lookAt;
                if (Input.GetMouseButton(0))
                    crosshair.sprite = lookCloser;
                _selection = selection.transform;
            }
            else
            {
                if (Input.GetMouseButton(0) && !isFocused)
                    Focus();
                _selection = selection.transform;
            }
        }
    }
    //Mouse "zoom in" switch indicator size when mouse clicked
    public void Focus()
    {
        if (!isFocused)
        {
            RectTransform rect = crosshair.rectTransform;
            rect.sizeDelta=new Vector2(rect.rect.width*0.5f, rect.rect.height * 0.5f);
            isFocused = true;
        }
    }
    //Mouse "zoom out" switch indicator size whem mouse released
    public void Unfocus()
    {
        if (isFocused)
        {
            RectTransform rect = crosshair.rectTransform;
            rect.sizeDelta = new Vector2(rect.rect.width * 2f, rect.rect.height * 2f);
            isFocused = false;
        }
    }
}
