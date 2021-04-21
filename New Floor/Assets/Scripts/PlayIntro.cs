using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayIntro : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Trying");
            NextStep();
        }
    }
    VideoPlayer video;
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;

    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        NextStep();
    }
    void NextStep()
    {
        //if(SceneManager.GetActiveScene.NextStep())
        string current = SceneManager.GetActiveScene().name;
        Debug.Log("current " + current);
        if (!current.Equals("CutScene")){
            SceneManager.LoadScene("Credits");
        }
        else
        {
            SceneManager.LoadScene(1);//the scene that you want to load after the video has ended.
        }
    }
}