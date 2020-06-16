using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
    [SerializeField]
    GameObject dome;

    private void OnMouseDown()
    {
        dome.SetActive(false);
    }
}
