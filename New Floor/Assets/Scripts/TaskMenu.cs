using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject starBurst, taskPanel;
    private Rect menuRect, smallRect;
    private bool isDisplayed = false;
    private Vector2 menuPosition;

    void Start()
    {
        //Replace for check for unseen tasks
        //Turn on notification for new task
        starBurst.SetActive(true);
        //Get and store menu dimensions
        menuRect = GetComponent<RawImage>().rectTransform.rect;
        smallRect = menuRect;
        menuPosition = GetComponent<RawImage>().rectTransform.transform.position;
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
                //AddTask();
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
    public void AddTask(Task task)
    {
        Text aTask = taskPanel.AddComponent<Text>();
        aTask.text = "";
        aTask.text = task.TaskText;
        Debug.Log("Some text: "+task.TaskText);
        //Set visuals
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        aTask.font = ArialFont;
        aTask.material = ArialFont.material;
        aTask.fontSize = 36;
        aTask.resizeTextForBestFit = true;
        aTask.alignment = TextAnchor.UpperCenter;
        aTask.color = Color.black;    
    }
}
