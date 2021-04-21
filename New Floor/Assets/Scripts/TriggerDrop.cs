using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDrop : MonoBehaviour
{
    [SerializeField]
    GameObject door, glassBox, glassBox2, taskStar, taskText1, taskText2, tipObject;
    [SerializeField]
    InteractableScreen screen;
    [SerializeField]
    TurnOnScreen turnOn;
    [SerializeField]
    Sprite[] tipNotes;
    [SerializeField]
    string[] tipTexts;
    [SerializeField]
    TMP_Text tipTextHolder;

    bool canScroll = false;

    private void Update()
    {
        if (canScroll)
        {
            if (Input.GetAxis("Mouse ScrollWheel") !=0 || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.K))
            {
                SwitchPages();
            }
        }
    }
    void SwitchPages()
    {
        taskText1.SetActive(!taskText1.activeSelf);
        taskText2.SetActive(!taskText2.activeSelf);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (gameObject.name.Equals("DoorOpenDrop"))
            {
                door.gameObject.GetComponent<Rigidbody>().AddForce(door.gameObject.transform.position, ForceMode.VelocityChange);

            }
            else if (gameObject.name.Equals("TriggerTaskDrop"))
            {
                glassBox.SetActive(false);
            }
            else if (gameObject.name.Equals("TriggerScreenOn"))
            {
                screen.IsEnabled = true;
                turnOn.IsEnabled = true;
            }
            else if (gameObject.name.Equals("TriggerScroll"))
            {
                canScroll = true;
            }
            else if (gameObject.name.Equals("TriggerTip"))
            {
                glassBox2.SetActive(false);
            }
        }
        else
        {
            if (gameObject.name.Equals("BallDrop"))
            {
                gameObject.SetActive(false);
            }
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name.Equals("DoorOpenDrop"))
        {
            gameObject.SetActive(false);
        }
        else if (gameObject.name.Equals("TriggerTaskDrop"))
        {
            glassBox.SetActive(true);
        }
        else if(gameObject.name.Equals("TriggerScreenOn"))
        {
            screen.IsEnabled = false;
            turnOn.IsEnabled = false;
        }
        else if (gameObject.name.Equals("TriggerScroll"))
        {
            canScroll = false;
        }
        else if (gameObject.name.Equals("TriggerTip"))
        {
            glassBox2.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.name.Equals("TaskButton"))
        {
            taskStar.SetActive(!taskStar.activeSelf);
            if (taskStar.activeSelf)
            {
                taskStar.GetComponent<AudioSource>().Play();
            }
        }
        else if (gameObject.name.Equals("TipButton"))
        {
            int index = Random.Range(0, tipNotes.Length);
            tipObject.GetComponent<SpriteRenderer>().sprite=tipNotes[index];
            index = Random.Range(0, tipTexts.Length);
            tipTextHolder.text = tipTexts[index];
        }
    }
}
