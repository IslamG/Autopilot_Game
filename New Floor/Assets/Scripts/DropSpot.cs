using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpot : MonoBehaviour
{
    //tbd better system trade-off between object and spot
    [SerializeField]
    GameObject targetObject, targetSpot;
    [SerializeField]
    TaskMenu taskMenu;

    private bool fired = false;
    public GameObject TargetSpot {get => targetSpot;}
    
    //If correct object placed inside of drop spot
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObj = other.gameObject;
        Debug.Log("fired " + fired);
        if (!fired && otherObj==targetObject)
        {
            Debug.Log("depositied item");
            fired = true;
            //tbd add reaction to successful deposite
            //possibly change remove system
            Task task = targetObject.GetComponent<Task>();
            task.IsCompleted = true;
            taskMenu.RemoveTaskFromList(task);
            Debug.Log("fired2 " + fired);
            OtherDisable(other.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    private void OtherDisable(GameObject otherObj)
    {
        otherObj.GetComponent<DropSpot>().enabled = false;
    }
    
}
