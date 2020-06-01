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
        if (fade)
        {
            color.CrossFadeAlpha(50f, 10.0f, false);
            //Debug.Log(color.color);
            Debug.Log("colors: " + (color.canvasRenderer.GetAlpha()));
            if (color.canvasRenderer.GetAlpha() >= 10.0f)
            {
                LeaveLevel();
            }
        }
        
    }
    public void Fade()
    {
        fade = true;
    }
    private void LeaveLevel()
    {
        //Load next scene
        this.enabled = false;
        //gameObject.SetActive(false);
        SceneManager.LoadScene("LoadingScreen");
    }
}
