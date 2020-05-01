using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    //Start game from main menu
    public void PlayGame()  
    {
        gameObject.SetActive(false);
        transition.SetBool("startNew", true);
    }
    //Quit game from main menu
    public void QuitGame()
    {
        Application.Quit();
    }
    //Switch to new scene
    public void SwitchScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
