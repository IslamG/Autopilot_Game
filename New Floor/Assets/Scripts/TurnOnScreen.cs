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
    [SerializeField]
    Camera screenCam;

    Camera mainCam;
    bool introVideoPlayed = false, helperDisplayed = false;
    Timer textTimer;

    public bool IsEnabled { get; set; } = true;
    public InteractableScreen OpenUI { get => openUI; set => openUI = value; }

    void Start()
    {
        //initialize variables
        //base.Start();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        if(vidPlayer!=null)
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
        if (vidPlayer != null)
            vidPlayer.targetTexture.Release();
        textTimer = gameObject.AddComponent<Timer>();
        textTimer.Duration = 5;
    }
    void OnMouseDown()
    {
        if (IsEnabled && !openUI.IsUp)
        {
            Camera useCam;
            if (screenCam != null)
            {
                useCam = screenCam;
            }
            else
            {
                useCam = mainCam;
            }
            Ray ray = useCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //item within grab distance i.e. 5 units 
            if (Physics.Raycast(ray, out hit, 3))
            {
                //base.OnMouseDown();
                //if mouse isn't over a screen that can open 
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                if (SceneManager.GetActiveScene().name.Equals("Opening"))
                    tipControl.GenerateTip(this.gameObject.GetComponent<TipScript>());
                if (vidPlayer != null)
                {
                    //Only play the boot up animation once
                    if (!introVideoPlayed)
                    {
                        //Play start up animation
                        vidPlayer.Play();
                        introVideoPlayed = true;
                    }
                    else
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                        Debug.Log("Open ui turn on screen : " + openUI.name);
                        openUI.SwitchToScreen();
                        //clear screen and revert back to main camera
                        //for viewing login screen
                        if (content != null)
                            content.DiscardContents();
                        //remove?
                        mainCam.gameObject.SetActive(true);
                        //mainCam.GetComponent<AudioListener>().enabled = true;
                    }
                }
                //Original if was here
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Debug.Log("Open ui turn on screen : " + openUI.name);
                    openUI.SwitchToScreen();
                    //clear screen and revert back to main camera
                    //for viewing login screen
                    if (content != null)
                        content.DiscardContents();
                    //remove?
                    mainCam.gameObject.SetActive(true);
                    //mainCam.GetComponent<AudioListener>().enabled = true;
                }
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
