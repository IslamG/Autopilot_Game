using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos, respawnPos;

    //When an object falls through boundry collider
    private void OnTriggerExit(Collider other)
    {
        //If respawning player
        //tbd respawn roughly back where the character started
        //currently moves character up and back
        if (other.gameObject.CompareTag("Player"))
        {
            respawnPos.x = other.gameObject.transform.position.x * 1;
            respawnPos.z = other.gameObject.transform.position.z * 1.075f;
            respawnPos.y = 1;
            other.gameObject.transform.position = respawnPos;
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
}
