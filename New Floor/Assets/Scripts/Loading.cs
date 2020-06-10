using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private Image _progressBar;

    private void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    //Asyncronious loading
    //the behavior goes on in the background
    //while the current scene (Loading screen) works in the foreground
    IEnumerator LoadAsyncOperation()
    {
        Debug.Log("loading: " + LevelTraversal.TargetLevel);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(LevelTraversal.TargetLevel);
        
        //tbd possibly put in that graphics later
        
        //while (gameLevel.progress < 1)
        //{
        //    _progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        //}
    }
}
