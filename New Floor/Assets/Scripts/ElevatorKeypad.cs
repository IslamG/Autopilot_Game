﻿using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ElevatorKeypad : MonoBehaviour
{
    [SerializeField]
    private ElevatorSequence sequence;
    [SerializeField]
    private FirstPersonController fpc;
    [SerializeField]
    private GameObject padImage, crosshair, targetHolder;
    private bool isPaused;
    CursorLockMode currentMouse;

    //If keypad is clicked
    void OnMouseDown()
    {
        //Stop main control 
        //And show keypad closeup image
        currentMouse = Cursor.lockState;
        padImage.SetActive(true);
        crosshair.SetActive(false);
        targetHolder.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fpc.enabled = false;
    }
    private void Update()
    {
        //If attempting to exit keypad closeup
        if (Input.GetMouseButton(1) && isPaused)
        {
            LeaveKeypad();
        }
    }
    public void LeaveKeypad()
    {
        //Hide keypad image and revert controls to normal
        padImage.SetActive(false);
        crosshair.SetActive(true);
        targetHolder.SetActive(true);
        Time.timeScale = 01f;
        isPaused = false;
        Cursor.lockState = currentMouse;
        fpc.enabled = true;
        //Reset the sequence pushed
        sequence.Reset();
    }
}
