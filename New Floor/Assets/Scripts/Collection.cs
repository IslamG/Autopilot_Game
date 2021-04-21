using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : Puzzle
{
    //An Object reference to a collection

    //the collection items
    [SerializeField]
    DropItem[] collectables;
    [SerializeField]
    DropSpot bossSpot;
    [SerializeField]
    GameObject passwordHint;

    private int itemsFound = 0;
    List<Task> tasksToRemove = new List<Task>();

    public int ItemsFound { get => itemsFound; }

    protected override void Start()
    {
        base.Start();
        EventManager.AddListener(FoundItem);
    }
    //Start wait before moving
    private void FoundItem(DropItem item)
    {
        StartCoroutine(Move(item));
    }
    private IEnumerator Move(DropItem item)
    {
        yield return new WaitForSeconds(1f);
        itemsFound += 1;
        Debug.Log("it " + itemsFound);
        //Move found item to collection position, next to any previous items
        Transform itemObj = item.gameObject.transform;
        float itemZ = gameObject.transform.position.z + (0.2f * itemsFound);
        float itemX = gameObject.transform.position.x;
        float itemY = gameObject.transform.position.y;
        itemObj.position = new Vector3(itemX, itemY, itemZ);
        itemObj.localEulerAngles = new Vector3(0, -90, 0);
        itemObj.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Task task=itemObj.gameObject.GetComponent<Task>();
        if (task != null)
            tasksToRemove.Add(task);

        //When all items are found, task is complete
        if (itemsFound == collectables.Length)
        {
            foreach(Task _task in tasksToRemove)
            {
                _task.gameObject.GetComponent<Puzzle>().Solve();
            }
            passwordHint.SetActive(true);
        }
        else
        {
            bossSpot.gameObject.SetActive(true);
        }
    }
}
