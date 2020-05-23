using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
    [SerializeField]
    private TMP_Text playText;
    [SerializeField]
    bool saveFile = false;
    //[SerializeField]
    //ZoomTransition zt;

    //tbd replace with savefile check
    private void Start()
    {
        if (!saveFile)
        {
            playText.text = "Start New";
        }
        else
        {
            playText.text = "Continue";
        }
    }
    public void PlayGame()  
    {
        gameObject.SetActive(false);
        transition.SetBool("startNew", true);
        //zt.MoveToCenter();
        //scene transition is called from animation end event in animator

    }
    //Quit game from main menu
    public void QuitGame()
    {
        Application.Quit();
    }
    //Switch to new scene
    public void SwitchScene()
    {
        //class return needs to be IEnumerator
        //yield return new WaitForSeconds(3.0f);
        if (saveFile)
        {
            //load floor level
            LevelTraversal.TargetLevel = "FloorTest";
        }
        else
        {
            //load opening scene
            LevelTraversal.TargetLevel = "Opening";
        }
        SceneManager.LoadScene("LoadingScreen");
    }
}
