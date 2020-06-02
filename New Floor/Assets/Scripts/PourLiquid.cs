using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PourLiquid : MonoBehaviour
{
    [SerializeField]
    GameObject liquid;

    private void OnMouseDown()
    {
        liquid.SetActive(!liquid.activeSelf);
    }

}
