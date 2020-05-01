using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ElevatorKeypad : MonoBehaviour
{
    public ElevatorSequence sequence; 
    public FirstPersonController fpc;
    public GameObject padImage, crosshair;
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
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fpc.enabled = false;
    }
    private void Update()
    {
        //If attempting to exit keypad closeup
        if (Input.GetKeyDown(KeyCode.Backspace) && isPaused)
        {
            LeaveKeypad();
        }
    }
    public void LeaveKeypad()
    {
        //Hide keypad image and revert controls to normal
        padImage.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 01f;
        isPaused = false;
        Cursor.lockState = currentMouse;
        fpc.enabled = true;
        //Reset the sequence pushed
        sequence.Reset();
    }
}
