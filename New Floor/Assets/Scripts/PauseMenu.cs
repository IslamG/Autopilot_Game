using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public FirstPersonController fpc;
    CursorLockMode currentMouse;
    float timeScale;
    bool fpcEnabled;

    void Update()
    {
        //pause button pressed to pause and unpause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    //Remove pause menu and resume gametime and fpc controller
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = timeScale;
        fpc.enabled = fpcEnabled;
        isPaused = false;
        Cursor.lockState = currentMouse;

    }
    //Display pause menu and pause gametime and fpc controller
    void Pause()
    {
        currentMouse = Cursor.lockState;
        timeScale = Time.timeScale;
        fpcEnabled = fpc.enabled;
        Debug.Log("Pause mousestate: " + currentMouse);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        fpc.enabled = false;
    }
    //Go to main
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainScreen");
    }
    //Quit to desktop
    public void QuitGame()
    {
        Application.Quit();
    }
}
