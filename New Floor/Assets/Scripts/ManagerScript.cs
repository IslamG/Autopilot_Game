using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    [SerializeField]
    RawImage menu;
    [SerializeField]
    Canvas hud;

    Rect menuRect;
    float menuHeight;
    float hudHeight;
    void Start()
    {
        menuRect = menu.uvRect;
        menuHeight = menu.uvRect.height;
        hudHeight = hud.pixelRect.height;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            DisplayMenu();
        }
    }
    private void DisplayMenu()
    {
        Debug.Log("menu: " + menuHeight + " hud: "+hudHeight);
        float percentage = hudHeight / menuHeight;
        menuHeight = hudHeight;
        float menuWidth = menu.uvRect.width * percentage;
        menu.uvRect =new Rect(menuWidth, menuHeight, 1,1);


    }
}
