using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
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
        private void FoundItem(DropItem item)
    {
        itemsFound+=1;
        Debug.Log("it " + itemsFound);
        Transform itemObj = item.gameObject.transform;
        //GameObject dropSpot = itemObj.GetComponent<DropItem>().TargetSpot.gameObject;
        float itemZ = gameObject.transform.position.z + (0.2f * itemsFound) ;
            //(itemObj.localScale.z * itemsFound);//+
        float itemX = gameObject.transform.position.x;
        float itemY = gameObject.transform.position.y;
        //itemObj.gameObject.GetComponent<BoxCollider>().enabled = false;
        //itemObj.gameObject.GetComponent<SphereCollider>().enabled = false;
        itemObj.localPosition = new Vector3(itemX, itemY, itemZ);
        itemObj.localEulerAngles = new Vector3(0, 180, 0);
        itemObj.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if (itemsFound == collectables.Length)
        {
            Task task = item.GetComponent<Task>();
            task.IsCompleted = true;
            taskMenu.RemoveTaskFromList(task);
        }
        
    }
}
