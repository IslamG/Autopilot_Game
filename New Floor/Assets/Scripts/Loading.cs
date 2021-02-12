using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Image[] loadingImg;

    private Image _progressBar;

    private void Start()
    {
        LoadingIcon();
        StartCoroutine(LoadAsyncOperation());
    }
    private void LoadingIcon()
    {
        //int count = loadingMator.runtimeAnimatorController.animationClips.Length;
        //Debug.Log("count " + count);
        //loading = new AnimationClip[count];
        //loading = loadingMator.runtimeAnimatorController.animationClips;
        //Pick a random sticky note sprite
        //int index = Random.Range(0, loading.Length);
        //loading = loadingMator.runtimeAnimatorController.animationClips;
        //Debug.Log(loading[index].name);
        //loadingMator.Play(loading[index].name);
        int index = Random.Range(0, loadingImg.Length);
        Debug.Log(loadingImg[index].name);
        loadingImg[index].gameObject.SetActive(true);
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
