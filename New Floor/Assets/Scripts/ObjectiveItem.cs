using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Object type class
//tbd probably remove
public class ObjectiveItem : MonoBehaviour
{
    private Task myTask;
    // Start is called before the first frame update
    void Start()
    {
        myTask = gameObject.GetComponent<Task>();
    }
    //Switch based on group type
    private void OnMouseDown()
    {
        switch (myTask.TaskGroup)
        {
            case 'g':
                {
                    Debug.Log("General");
                    break;
                }
            case 'j':
                {
                    Debug.Log("Jeremy");
                    break;
                }
            case 'm':
                {
                    Debug.Log("Maisy");
                    break;
                }
            case 'b':
                {
                    Debug.Log("Boss");
                    break;
                }
            case 'p':
                {
                    Debug.Log("Paul");
                    break;
                }
        }
    }
}
