using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
    //[SerializeField]
    //ZoomTransition zt;
    //Start game from main menu
    public void PlayGame()  
    {
        gameObject.SetActive(false);
        transition.SetBool("startNew", true);
        //zt.MoveToCenter();

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
