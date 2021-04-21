using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instace;

    public delegate void DelegateFunc();
    DelegateFunc del;

    [SerializeField]
    private Animator transition;
    [SerializeField]
    private TMP_Text playText;
    [SerializeField]
    private Image background;
    [SerializeField]
    private RectTransform rect_Panel, bTrans;
    [SerializeField]
    GameObject mainMenu, restartPopUp, quitPopUp, popUpGen;
    [SerializeField]
    private Button newButton;

    //[SerializeField]
    //ZoomTransition zt;

    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    bool isReady = false, created = false, hasSave;

    //private ResetDelegate ResetDelegate { get => resetDelegate;}

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
        Debug.Log("The color at quarter: " + gradient.Evaluate(0.25f));
        if (!hasSave)
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
        //Debug.Log("Enable");
    }
    private void Awake()
    {
        if (!created)
        {
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
        //Check if there's a save file before starting main menu
        string path = Application.persistentDataPath + "/save_info.sve";
        hasSave = File.Exists(path);
        //Debug.Log("Awake "+path);
        if (hasSave)
        {
            newButton.gameObject.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    //change play game button text depending on if there's a save file
    private void Start()
    {
        if (!hasSave)
        {
            playText.text = " Start New ";
        }
        else
        {
            playText.text = " Continue ";
        }
    }
    //hide menu and start transition animation
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        transition.SetBool("startNew", true);
        //zt.MoveToCenter();
        //scene transition is called from animation end event in animator

    }
    //When restart clicked turn on confirmation pop up
    //and delegate restart action to pop up
    public void RestartClicked()
    {
        restartPopUp.GetComponent<PopUp>().ShowPop();
        del = RestartGame;
        popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
        popUpGen.gameObject.SetActive(true);
    }
    //Restarting game delete any save with old progress
    //start a new game
    private void RestartGame()
    {
        File.Delete(Application.persistentDataPath + "/save_info.sve");
        hasSave = false;
        PlayGame();
    }
    //When quit clicked turn on confirmation pop up
    //and delegate quit action to pop up
    public void QuitClicked()
    {
        quitPopUp.GetComponent<PopUp>().ShowPop();
        del = QuitGame;
        popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
        popUpGen.gameObject.SetActive(true);
    }
    //Quit game from main menu
    private void QuitGame()
    {
        Application.Quit();
    }
    //Switch to new scene
    public void SwitchScene()
    {
        //class return needs to be IEnumerator
        if (hasSave)
        {
            SaveData data = SaveGame.LoadData();

            //load floor level
            LevelTraversal.TargetLevel = data.LevelName;
        }
        else
        {
            //load opening scene
            LevelTraversal.TargetLevel = "Opening";
        }
        SceneManager.LoadScene("LoadingScreen");
    }
}
