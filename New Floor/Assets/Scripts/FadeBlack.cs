using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    Image color;
    bool fade = false;
    Color targetColor;
    private void Start()
    {
        color = gameObject.GetComponent<Image>();
        targetColor = new Color(0, 0, 0, 255);
    }
    private void Update()
    {
        //If fade triggered
        if (fade)
        {
            //Fade color into black
            color.CrossFadeAlpha(255f, 5.0f, false);
            Debug.Log("colors: " + (color.canvasRenderer.GetAlpha()));
            if (color.canvasRenderer.GetAlpha() >= 100.0f)
            {
                //Once color reached, load next level
                LeaveLevel();
            }
        }
        
    }
    public void Fade()
    {
        fade = true;
        Debug.Log("Fade");
    }
    private void LeaveLevel()
    {
        //Load next scene
        this.enabled = false;
        SceneManager.LoadScene("LoadingScreen");
    }
}
