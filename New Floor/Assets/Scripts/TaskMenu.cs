using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject starBurst, taskPanel;
    [SerializeField]
    private TMP_Text taskText;
    private Rect menuRect, smallRect;
    private bool isDisplayed = false;
    private Vector2 menuPosition;

    private List<Task> activeTaskList = new List<Task>();
    private List<Task> completedTaskList = new List<Task>();

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
        if (Input.GetKeyDown(KeyCode.M))
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
    }
    //Return menu to bottom of screen
    private void MinimizeMenu()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(smallRect.width, smallRect.height);
        GetComponent<RectTransform>().SetPositionAndRotation(
            menuPosition, Quaternion.identity);
        if (taskPanel.GetComponent<Text>() != null)
            taskPanel.GetComponent<Text>().gameObject.SetActive(false);
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
            taskText.text += task.TaskText;
            taskText.text += "\n";
        }
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
