using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour
{
    private Task myTask;
    // Start is called before the first frame update
    void Start()
    {
        myTask = gameObject.GetComponent<Task>();
    }
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
