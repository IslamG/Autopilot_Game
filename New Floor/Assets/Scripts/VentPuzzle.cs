using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentPuzzle : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        Debug.Log("Left");
        SceneManager.LoadScene("LoadingScreen");
    }

    
}
