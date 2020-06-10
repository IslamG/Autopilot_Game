using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Collection : MonoBehaviour
{
    //An Object reference to a collection

    //the collection items
    [SerializeField]
    DropItem[] collectables;
    [SerializeField]
    TaskMenu taskMenu;

    private int itemsFound = 0;

    public int ItemsFound { get => itemsFound; }

    private void Start()
    {
        EventManager.AddListener(FoundItem);
    }
    //Start wait before moving
    private void FoundItem(DropItem item)
    {
        StartCoroutine(Move(item));     
    }
    private IEnumerator Move (DropItem item)
    {
        yield return new WaitForSeconds(1f);
        itemsFound += 1;
        Debug.Log("it " + itemsFound);
        //Move found item to collection position, next to any previous items
        Transform itemObj = item.gameObject.transform;
        float itemZ = gameObject.transform.position.z + (0.2f * itemsFound);
        float itemX = gameObject.transform.position.x;
        float itemY = gameObject.transform.position.y;
        itemObj.localPosition = new Vector3(itemX, itemY, itemZ);
        itemObj.localEulerAngles = new Vector3(0, 180, 0);
        itemObj.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //When all items are found, task is complete
        if (itemsFound == collectables.Length)
        {
            Task task = item.GetComponent<Task>();
            task.IsCompleted = true;
            taskMenu.RemoveTaskFromList(task);
        }
    }
}
