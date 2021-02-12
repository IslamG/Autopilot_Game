using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class TurnOnScreen : MonoBehaviour
{
    [SerializeField]
    RenderTexture content;
    [SerializeField]
    TMP_Text helperText;
    [SerializeField]
    TipsControl tipControl;
    [SerializeField]
    InteractableScreen openUI;
    [SerializeField]
    VideoPlayer vidPlayer;
    Camera mainCam;
    bool introVideoPlayed = false, helperDisplayed = false;
    Timer textTimer;

    public bool IsEnabled { get; set; } = true;

    void Start()
    {
        //initialize variables
        //base.Start();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        vidPlayer.loopPointReached += EndReached;
        mainCam = Camera.main;
        Debug.Log("Initializing in Trun on screen open ui= " + openUI);
    }
    //Switch view from closeup camera to main 
    void Update()
    {
        //base.Update();
        //Hide helper text after duration
        if (textTimer.Finished && helperDisplayed)
        {
            helperText.text = "";
        }
    }
    void Awake()
    {
        //vidPlayer = GetComponentInChildren<VideoPlayer>();
        vidPlayer.targetTexture.Release();
        textTimer = gameObject.AddComponent<Timer>();
        textTimer.Duration = 5;
    }
    void OnMouseDown()
    {
        if (IsEnabled)
        {
            //base.OnMouseDown();
            //if mouse isn't over a screen that can open 
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (SceneManager.GetActiveScene().name.Equals("Opening"))
                tipControl.GenerateTip(this.gameObject.GetComponent<TipScript>());
            //Only play the boot up animation once
            if (!introVideoPlayed)
            {
                //Play start up animation
                vidPlayer.Play();
                introVideoPlayed = true;
            }
            else
            {
                openUI.SwitchToScreen();
                //clear screen and revert back to main camera
                //for viewing login screen
                content.DiscardContents();
                //remove?
                mainCam.gameObject.SetActive(true);
                //mainCam.GetComponent<AudioListener>().enabled = true;
            }
        }

    }
    //When startup animation finished playing
    void EndReached(VideoPlayer videoPlayer)
    {
        if (IsEnabled)
        {
            openUI.SwitchToScreen();

            //Display helper text only once
            if (!helperDisplayed && helperText != null)
            {
                helperText.text = "I think I wrote clues to my password somewhere";
                textTimer.Run();
                helperDisplayed = true;
            }
        }

    }
    /*
    //Bring up login screen UI
    private void SwitchToLogin()
    {
        gameObject.GetComponent<InteractableScreen>().SwitchToLogin();
        //clear screen and revert back to main camera
        //for viewing login screen
        content.DiscardContents();
        //remove?
        mainCam.gameObject.SetActive(true);
        //mainCam.GetComponent<AudioListener>().enabled = true;
    }*/
}
