using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentPuzzle : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.name.Equals("Exit"))
        {
            Exit();
        }
        else
        {
            LoadOut();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered vent by: "+other.gameObject.name);
        if (gameObject.name.Equals("Exit"))
        {
            Exit();
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                LoadOut();
            }
        } 
    }
    private void LoadOut()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
    private void Exit()
    {
        //LevelTraversal.TargetLevel = "FloorTest";
    }
}
