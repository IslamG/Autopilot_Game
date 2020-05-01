using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTransition : MonoBehaviour
{
    private MainMenu menu;
    void Start()
    {
        //tbd add slerp to smooth animation
        menu = transform.parent.GetComponentInChildren<MainMenu>();
    }
    public void Switch()
    {
        menu.SwitchScene();
    }

}
