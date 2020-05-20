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

    private void Start()
    {
        viewCamera = gameObject.GetComponent<Camera>();
    }
    private void Update()
    {
        if (_selection != null)
        {
            crosshair.sprite = defaultMouse;
        }
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, reach))
        {
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
