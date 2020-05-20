using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpot : MonoBehaviour
{
    [SerializeField]
    GameObject targetObject, targetSpot;
    [SerializeField]
    TaskMenu taskMenu;

    private bool fired = false;

    public GameObject TargetSpot { get => targetSpot; }
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObj = other.gameObject;
        if (!fired && otherObj==targetObject)
        {
            Debug.Log("depositied item");
            fired = true;
            Task task = targetObject.GetComponent<Task>();
            taskMenu.RemoveTaskFromList(task);
        }
    }
    
}
