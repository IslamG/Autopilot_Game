using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScreens : MonoBehaviour
{
    void Start()
    {
        //gameObject.loopPointReached += EndReached;
    }

    void EndReached()
    {
        
    }
    private void OnMouseDown()
    {
        Camera.main.gameObject.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
