using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    private TMP_Text helperText;
    private GameObject player;
    private Vector3 playerPos, respawnPos;
    private static int fallTimes = 0;
    private Timer textTimeout;
    private bool textDisplayed = false;

    //Reset text after some time
    private void Start()
    {
        textTimeout = gameObject.AddComponent<Timer>();
        textTimeout.Duration = 3;
    }

    private void Update()
    {
        if (textTimeout.Finished && textDisplayed)
        {
            helperText.text = "";
            textDisplayed = false;
        }
    }

    //When an object falls through boundry collider
    private void OnTriggerExit(Collider other)
    {
        //If respawning player
        //tbd respawn roughly back where the character started
        //currently moves character up and back
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 root=gameObject.transform.position;
            //respawnPos.x = other.gameObject.transform.position.x * 1;
            //respawnPos.z = other.gameObject.transform.position.z * 1.075f;
            //respawnPos.y = 1;
            root.y -= other.transform.localScale.y;
            other.gameObject.transform.position = root; //respawnPos;
            SetText();
        }
        //If respawning object 
        else
        {
            //Find player and place object near their position
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            playerPos = player.transform.localPosition;
            respawnPos = playerPos * 1.025f;
            other.gameObject.transform.position = respawnPos;
        }
    }
    //Show text when object is thrown put of the building
    //And run timer to make the text disappear
    private void SetText()
    {
        fallTimes += 1;
        switch (fallTimes)
        {
            case 1:
                {
                    helperText.text = "Whoa that's trippy";
                    break;
                }
            case 2:
                {
                    helperText.text = "Hey that's kind of fun";
                    break;
                }
            case 3:
                {
                    helperText.text = "Weeeeeeeeeeee";
                    break;
                }
            case 4:
                {
                    helperText.text = "Okay that's enough";
                    break;
                }
            default:
                {
                    helperText.text = "This stopped being fun "+(fallTimes - 3)+ " times ago";
                    break;
                }
        }
        textDisplayed = true;
        textTimeout.Run();
    }
}
