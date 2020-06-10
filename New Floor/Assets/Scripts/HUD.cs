using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    void Awake()
    {
        if (instance==null)
        {
            //create
        }
        else
        {
            //Exists already
            //Destroy(this.gameObject);
        }
    }
}
