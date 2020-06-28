using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpot : MonoBehaviour
{
    //tbd better system trade-off between object and spot
    [SerializeField]
    GameObject targetObject;
    [SerializeField]
    TaskMenu taskMenu;

    private bool fired = false;
    
    //If correct object placed inside of drop spot
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObj = other.gameObject;
        if (!fired && otherObj==targetObject)
        {
            Debug.Log("depositied item");
            fired = true;
            //tbd add reaction to successful deposite
            //possibly change remove system
            Task task = targetObject.GetComponent<Task>();
            task.IsCompleted = true;
            taskMenu.RemoveTaskFromList(task);
            //Disable drop spot and item scripts
            OtherDisable(other.gameObject);
            this.gameObject.SetActive(false);
        }
        else
        {
            CapsuleCollider[] col = gameObject.GetComponents<CapsuleCollider>();
            foreach(CapsuleCollider bump in col)
            {
                if (!bump.isTrigger)
                {
                    bump.enabled = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CapsuleCollider[] col = gameObject.GetComponents<CapsuleCollider>();
        foreach (CapsuleCollider bump in col)
        {
            if (!bump.isTrigger)
            {
                bump.enabled = true;
            }
        }
    }
    //Called when completed
    private void OtherDisable(GameObject otherObj)
    {
        DropItem drop = otherObj.GetComponent<DropItem>();
        //If a collectable is found, trigger the collection event
        if (drop.IsCollectable)
        {
            drop.itemFound.Invoke(drop);
        }
        drop.enabled = false;
    }
    
}
