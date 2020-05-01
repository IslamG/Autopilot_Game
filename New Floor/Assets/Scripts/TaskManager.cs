using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private GameObject taskMenu, starBurst;
    private Rect menuRect, smallRect;

    void Start()
    {
        //Replace for check for unseen tasks
        //Turn on notification for new task
        starBurst.SetActive(true);
        //Get and store menu dimensions
        menuRect = taskMenu.GetComponent<RawImage>().rectTransform.rect;
        smallRect = menuRect;
    }
     void Update()
    {
        //If menu button pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Hide notifications
            starBurst.SetActive(false);
            //Show menu in full size
            DisplayMenu();
        }
    }
    //Open up menue in screen middle
    private void DisplayMenu()
    {
        //Enlarging ration, use to resize width accordingly
        float ratio = Screen.height / menuRect.height;
        //change menu size
        menuRect.height = Screen.height;
        menuRect.width *= ratio;
        taskMenu.GetComponent<RectTransform>().sizeDelta= new Vector2(menuRect.width,menuRect.height);
        taskMenu.GetComponent<RectTransform>().SetPositionAndRotation(
            new Vector3(Screen.width/2-(menuRect.width/2),
            0, 0), Quaternion.identity);
    }
}
