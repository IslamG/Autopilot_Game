using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PourLiquid : MonoBehaviour
{
    [SerializeField]
    GameObject liquid;
    public bool IsEnabled { get; set; } = true;
    //When item clicked, play/stop pour animation
    //tbd switch based on part of item pressed for objects
    //with multiple outputs of liquid
    private void OnMouseDown()
    {
        if (IsEnabled)
        {
            //Switch active state
            liquid.SetActive(!liquid.activeSelf);
            Debug.Log("Liquid Trigger");
        }
        
    }

}
