using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ElevatorKeypad : MonoBehaviour
{
    public FirstPersonController fpc;
    public GameObject padImage, crosshair;
    private bool isPaused;
    CursorLockMode currentMouse;

    void OnMouseDown()
    {
        currentMouse = Cursor.lockState;
        Debug.Log("Keybad mousestate: " + currentMouse);
        padImage.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        fpc.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && isPaused)
        {
            padImage.SetActive(false);
            crosshair.SetActive(true);
            Time.timeScale = 01f;
            isPaused = false;
            Cursor.lockState = currentMouse;
            fpc.enabled = true;
        }
    }
}
