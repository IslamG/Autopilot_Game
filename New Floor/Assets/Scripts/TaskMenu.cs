using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskMenu : MonoBehaviour
{
    public static TaskMenu instance;

    [SerializeField]
    private GameObject starBurst, taskPanel, 
        blueTape, orangeTape, greenTape, purpleTape;
    [SerializeField]
    private TMP_Text taskText;
    [SerializeField]
    private TipsControl tipControl;
    [SerializeField]
    private Image paperImg;

    private Rect menuRect, smallRect, paperRect;
    private bool isDisplayed = false;
    private Vector2 menuPosition;

    private List<Task> activeTaskList = new List<Task>();
    private List<Task> completedTaskList = new List<Task>();

    //Singleton class
    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    void Start()
    {
        //Get and store menu dimensions
        menuRect = GetComponent<RawImage>().rectTransform.rect;
        smallRect = menuRect;
        menuPosition = GetComponent<RawImage>().rectTransform.transform.position;
        EventManager.AddListener(AddActiveTaskToList);
    }
    void Update()
    {
        //If menu button pressed
        if (Input.GetKeyDown(KeyCode.M) && !PauseMenu.isPaused)
        {
            isDisplayed = !isDisplayed;
            if (isDisplayed)
            {
                //Hide notifications
                starBurst.SetActive(false);
                //Show menu in full size
                DisplayMenu();
            }
            else
            {
                MinimizeMenu();
            }
        }
    }
    //Open up menu in screen middle
    private void DisplayMenu()
    {
        //Enlarging ratio, use to resize width accordingly
        float ratio = Screen.height / menuRect.height;
        //change menu size
        menuRect.height = Screen.height;
        menuRect.width *= ratio;
        GetComponent<RectTransform>().sizeDelta = new Vector2(menuRect.width, menuRect.height);
        GetComponent<RectTransform>().SetPositionAndRotation(
            new Vector3(Screen.width / 2 - (menuRect.width / 2),
            0, 0), Quaternion.identity);
        if (taskPanel.GetComponent<Text>() != null)
            taskPanel.GetComponent<Text>().gameObject.SetActive(true);
        //tbd add check for person specific quests
        blueTape.SetActive(true);
        orangeTape.SetActive(true);
        greenTape.SetActive(true);
        purpleTape.SetActive(true);

        paperImg.GetComponentInChildren<Text>().fontSize = 32;
    }
    //Return menu to bottom of screen
    private void MinimizeMenu()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(smallRect.width, smallRect.height);
        GetComponent<RectTransform>().SetPositionAndRotation(
            menuPosition, Quaternion.identity);
        if (taskPanel.GetComponent<Text>() != null)
            taskPanel.GetComponent<Text>().gameObject.SetActive(false);

        blueTape.SetActive(false);
        orangeTape.SetActive(false);
        greenTape.SetActive(false);
        purpleTape.SetActive(false);

        //use the image rect which resizes automaticall
        //to set rect for text
        Text _text = paperImg.GetComponentInChildren<Text>();
        Rect _rect = paperImg.GetComponent<RectTransform>().rect;
        _text.fontSize = 9;
        _text.GetComponent<RectTransform>().sizeDelta =
            paperImg.GetComponent<RectTransform>().sizeDelta;
            //new Vector2(
            //_rect.width, _rect.height);

    }
    //Add active tasks to the list
    private void AddActiveTaskToList(Task task)
    {
        starBurst.SetActive(true);
        activeTaskList.Add(task);
        activeTaskList = activeTaskList.Distinct().ToList();
        AddTaskToMenu();
    }
    //Show task text on menu
    //Called when a new task becomes active
    private void AddTaskToMenu()
    {
        taskText.text = "";
        foreach(Task task in activeTaskList)
        {
            GameObject _obj = new GameObject("Text");
            Text _text=_obj.AddComponent<Text>();
            _text.text = task.TaskText;
            _text.transform.position = taskText.transform.position;
            _text.transform.localScale = taskText.transform.localScale;
            _text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");//(TMP_FontAsset)taskText.font;
            _text.fontSize = 8;//taskText.fontSize;
            _text.color = Color.black;
            paperRect = _text.GetComponent<RectTransform>().rect;

            _obj.transform.SetParent(paperImg.transform);
            //taskText.text += task.TaskText;
            //taskText.text += "\n";
        }
        TipScript script = this.gameObject.GetComponent<TipScript>();
        if(script!=null)
            tipControl.GenerateTip(script);
    }
    //Remove task text from menu
    //Used mainly when active task is completed
    public void RemoveTaskFromList(Task task)
    {
        activeTaskList.Remove(task);
        if (activeTaskList.Count < 1)
        {
            starBurst.SetActive(false);
        }
        AddTaskToMenu();
    }
}
