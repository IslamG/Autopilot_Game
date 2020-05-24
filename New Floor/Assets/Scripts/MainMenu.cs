using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
    [SerializeField]
    private TMP_Text playText;
    [SerializeField]
    bool saveFile = false;
    [SerializeField]
    private Image background;
    //[SerializeField]
    //ZoomTransition zt;

    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    private void SetColor()
    {
        gradient = new Gradient();

        colorKey = new GradientColorKey[4];
        colorKey[0].color = Color.white;
        colorKey[0].time = 0.0f;
        colorKey[1].color = new Color32(224, 223, 207, 255);//daylight color
        colorKey[1].time = 0.15f;
        colorKey[2].color = new Color32(18, 34, 43, 255);//Evening color
        colorKey[2].time = 0.9f;
        colorKey[3].color = new Color32(7, 20, 27, 255);//Night color
        colorKey[3].time = 1.0f;

        //Alpha keys (values at points)
        alphaKey = new GradientAlphaKey[4];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.15f;
        alphaKey[2].alpha = 1.0f;
        alphaKey[2].time = 0.9f;
        alphaKey[3].alpha = 1.0f;
        alphaKey[3].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        //find value at time/%
        //tbd replace with current time get, calculate percent
        //then assign evaluate value to background tint;
        Debug.Log("The color at quarter: "+gradient.Evaluate(0.25f));
        if (!saveFile)
        {
            //No file= new day, earliest time
            background.color = gradient.Evaluate(0.0f);
        }
        else
        {
            //There is a save
            //tbd replace with color equivalant to time elapsed in-game
            background.color = gradient.Evaluate(0.9f);//default color for now
        }
    }
    private void OnEnable()
    {
        SetColor(); 
    }
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
