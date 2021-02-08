using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggTransition : MonoBehaviour
{
    [SerializeField]
    Material newSky, oldSky;
    [SerializeField]
    GameObject returnSign, markerSign;

    bool isFound = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&!isFound)
        {
            RenderSettings.skybox = newSky;
            isFound = true;
            markerSign.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        if (gameObject.name.Equals(returnSign.name))
        {
            RenderSettings.skybox = oldSky;
            reSpawn();
        }
    }
    public void reSpawn()
    {
        GameObject player=GameObject.FindGameObjectsWithTag("Player")[0];
        player.transform.position = markerSign.transform.position;
    }
}
