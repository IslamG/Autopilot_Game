using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    private TMP_Text helperText;
    [SerializeField]
    private AudioClip[] appearSound;
    [SerializeField]
    AudioMixer mixer;

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
        //When text shown timer finishes hide text
        if (textTimeout.Finished && textDisplayed)
        {
            helperText.text = "";
            textDisplayed = false;
        }
    }
    //When an object falls through boundry collider
    private void OnTriggerEnter(Collider other)
    {
        //Respawn(other);
    }
    //When an object falls through boundry collider
    private void OnTriggerExit(Collider other)
    {
        Respawn(other);
        //Debug.Log("Fell out of bounds");
    }
    //Position back in boundries
    private void Respawn(Collider other)
    {
        //If respawning player
        //tbd respawn roughly back where the character started
        //currently moves character up and back
        if (other.gameObject.name.Equals("Cone")){
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 root = gameObject.transform.position;
            root.y -= other.transform.localScale.y;
            other.gameObject.transform.position = root;
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
        AudioSource source = other.GetComponent<AudioSource>();
        if (source == null)
        {
            source=other.gameObject.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = mixer.FindMatchingGroups("Enviroment")[0];
            int rand= Random.Range(0, appearSound.Length);
            source.clip = appearSound[rand];
        }
        source.Play();
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
