using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PourLiquid : MonoBehaviour
{
    [SerializeField]
    GameObject liquid;

    //When item clicked, play/stop pour animation
    //tbd switch based on part of item pressed for objects
    //with multiple outputs of liquid
    private void OnMouseDown()
    {
        //Switch active state
        liquid.SetActive(!liquid.activeSelf);
        Debug.Log("Liquid Trigger");
    }

}
