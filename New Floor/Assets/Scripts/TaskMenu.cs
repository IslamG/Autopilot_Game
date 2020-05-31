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
    private static bool isDisplayed = false; 
    private bool addedTask=false;
    private Vector2 menuPosition;
    private char activeGroup='g';
    private float mouseScroll;

    private List<Task> activeTaskList = new List<Task>();
    private List<Task> completedTaskList = new List<Task>();
    //private Dictionary<char, Task> pairList = new Dictionary<char, Task>();

    public static bool IsDisplayed { get => isDisplayed; }
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
        //Allow to scroll through tabs
        if(isDisplayed && !PauseMenu.isPaused)
        {
            if (Input.GetAxis("Mouse ScrollWheel")<0)
            {
                mouseScroll -= 1; 
                mouseScroll = Mathf.Clamp(mouseScroll, -4, 4);//prevents value from exceeding specified range
                Debug.Log("mm "+Input.GetAxis("Mouse ScrollWheel"));
                Debug.Log("m " + mouseScroll);
                SwitchPages();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                mouseScroll += 1;
                mouseScroll = Mathf.Clamp(mouseScroll, -5, 5);
                Debug.Log("mm " + Input.GetAxis("Mouse ScrollWheel"));
                Debug.Log("m " + mouseScroll);
                SwitchPages();
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
        
        blueTape.SetActive(true);
        orangeTape.SetActive(true);
        greenTape.SetActive(true);
        purpleTape.SetActive(true);

        TextMeshProUGUI[] displayedTasks = paperImg.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI _child in displayedTasks)
        {
            _child.fontSize = 32;
        }
    }
    //Return menu to bottom of screen
    private void MinimizeMenu()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(smallRect.width, smallRect.height);
        //GetComponent<RectTransform>().SetPositionAndRotation(
        //    menuPosition, Quaternion.identity);
        //GetComponent<RectTransform>()
        if (taskPanel.GetComponent<Text>() != null)
            taskPanel.GetComponent<Text>().gameObject.SetActive(false);

        blueTape.SetActive(false);
        orangeTape.SetActive(false);
        greenTape.SetActive(false);
        purpleTape.SetActive(false);

        TextMeshProUGUI[] displayedTasks = paperImg.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI _child in displayedTasks)
        {
            _child.fontSize = 8;
        }

    }
    //Add active tasks to the list
    private void AddActiveTaskToList(Task task)
    {
        starBurst.SetActive(true);
        activeTaskList.Add(task);
        activeTaskList = activeTaskList.Distinct().ToList();
        AddTaskToMenu();
        //HighlightStrip();
    }
    //Show task text on menu
    //Called when a new task becomes active
    private void AddTaskToMenu()
    {//tbd fix dynamic adding to not have to reset each time
        
        TextMeshProUGUI[] displayedTasks = paperImg.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI _child in displayedTasks)
        {
            Destroy(_child.gameObject);
        }
        foreach (Task task in activeTaskList)
        {
            Debug.Log("In loop " + activeGroup);
            if (task.TaskGroup == activeGroup)
            {
                taskText.text = "";
                GameObject _obj = new GameObject("Text");
                TextMeshProUGUI _text=_obj.AddComponent<TextMeshProUGUI>();
                _text.text = ("•   "+task.TaskText);
                if (isDisplayed)
                {
                    _text.fontSize = 32;
                }
                else
                {
                     _text.fontSize = 8;
                }
                _text.color = Color.black;
            
                _obj.transform.SetParent(paperImg.transform);

            }  
        }
        displayedTasks = paperImg.GetComponentsInChildren<TextMeshProUGUI>();
        Debug.Log("This many " + displayedTasks.Length + " in " + activeGroup);
        if (displayedTasks.Length < 1)
        {
            taskText.text = "No Active Tasks in this category";
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
            taskText.text = "No Active Tasks in This Catagory";
        }
        AddTaskToMenu();
    }
    private void HighlightStrip()
    {
        //Switch highlighted strip based on active group
        switch (activeGroup)
        {
            //Jeremy's tasks active
            case 'j':
                {/*
                    Outline other = greenTape.GetComponent<Outline>();
                    if (other != null)
                    {
                        Destroy(other);
                    }
                    other = orangeTape.GetComponent<Outline>();
                    if (other != null)
                    {
                        Destroy(other);
                    }
                    other = blueTape.GetComponent<Outline>();
                    if (other != null)
                    {
                        Destroy(other);
                    }
                    other = purpleTape.GetComponent<Outline>();
                    if (other != null)
                    {
                        Destroy(other);
                    }

                    Outline outline=blueTape.AddComponent<Outline>();
                    outline.effectDistance = new Vector2(6, -6);
                    outline.effectColor = new Color(255,255,0, 0.25f);
                    */

                    paperImg.transform.parent.SetAsLastSibling();
                    blueTape.transform.SetAsLastSibling();

                    break;
                }
            //Maisy's taks active
            case 'm':
                {
                    paperImg.transform.parent.SetAsLastSibling();
                    orangeTape.transform.SetAsLastSibling();

                    break;
                }
            //Boss Tyrant's tasks active
            case 'b':
                {
                    paperImg.transform.parent.SetAsLastSibling();
                    purpleTape.transform.SetAsLastSibling();

                    break;
                }
            //Paul's tasks active
            case 'p':
                {
                    paperImg.transform.parent.SetAsLastSibling();
                    greenTape.transform.SetAsLastSibling();

                    break;
                }
            //General tasks active
            default:
                {
                    paperImg.transform.parent.SetAsLastSibling();

                    break;
                }
        }
        //TBD possibly replace Addtask call with highlight call
        AddTaskToMenu();
    }
    private void SwitchPages()
    {
        //Switch between tabs with mousescroll value 
        if (mouseScroll == (-1) || mouseScroll == (4))
        {
            activeGroup = 'j';
        }

        else if(mouseScroll == (-2) || mouseScroll == (3))
        {
            activeGroup = 'm';
        }

        else if (mouseScroll == (-3) || mouseScroll == (2))
        {
            activeGroup = 'p';

        }
        else if (mouseScroll == (-4) || mouseScroll == (1))
        {
            activeGroup = 'b';
        }
        else
        {
            activeGroup = 'g';
        }
        HighlightStrip();
    }
}
