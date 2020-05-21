using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Start()
    {
        //If there is a task that comes with beginning of game
        //activate it
        Task task = gameObject.GetComponent<Task>();
        if (task != null)
        {
            task.ActivateTask();
        }
        
    }
}
