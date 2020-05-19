using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private FirstPersonController fpc;
    [SerializeField]
    private CameraLook[] cams;
    [SerializeField]
    private VideoPlayer vid;

    CursorLockMode currentMouse;
    bool isCursorVisible;
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

        isPaused = false;
        //Return states to how they were before pausing
        Cursor.lockState = currentMouse;
        Cursor.visible = isCursorVisible;

        //Enable look control
        if (fpc!=null)
            fpc.enabled = fpcEnabled;
        else
        {
            foreach (CameraLook cam in cams)
            {
                cam.enabled = true;
            }
        }
        if (vid != null)
        {
            if (vid.isPaused)
            {
                vid.Play();
            }
        }  
    }
    //Display pause menu and pause gametime and fpc controller
    void Pause()
    {
        //Store states before pause
        currentMouse = Cursor.lockState;
        isCursorVisible = Cursor.visible;
        timeScale = Time.timeScale;

        if (fpc != null)
            fpcEnabled = fpc.enabled;
        Debug.Log("Pause mousestate: " + currentMouse);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Disable look control
        if (fpc != null)
            fpc.enabled = false;
        else
        {
            foreach(CameraLook cam in cams)
            {
                cam.enabled = false;
            }
        }
        if (vid != null)
        {
            if (vid.isPlaying)
            {
                vid.Pause();
            }
        }
        
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
