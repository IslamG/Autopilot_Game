using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseIndicator : MonoBehaviour
{
    [SerializeField]
    Sprite defaultMouse, grabMouse, clickMouse;
    [SerializeField]
    private float reach;
    [SerializeField]
    Image crosshair;

    Camera viewCamera;
    private Transform _selection;
    //Camera that's being used for main control
    //tbd manage camera switching
    private void Start()
    {
        viewCamera = gameObject.GetComponent<Camera>();
    }
    private void Update()
    {
        //If not currently over any special object
        if (_selection != null)
        {
            crosshair.sprite = defaultMouse;
        }

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, reach))
        {
            //tbd add state for when mouse held down (holding object)
            //If hovering over special object, use correct mouse icon
            GameObject selection = hit.transform.gameObject;
            if (selection.CompareTag("Selectable"))
            {
                crosshair.sprite = grabMouse;
                _selection = selection.transform;
            }
            else if (selection.CompareTag("Clickable"))
            {
                crosshair.sprite = clickMouse;
                _selection = selection.transform;
            }
        }
    }
}
