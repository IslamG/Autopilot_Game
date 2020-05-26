using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        string currenLvl = SceneManager.GetActiveScene().name;

        /*Game initilizer code works across scenes
        check if the opening scene and set next level to main level
        on the floor level puzzles will control if there'll 
        be another scene loaded in and what it is*/

        if (currenLvl.Equals("Opening"))
        {
            LevelTraversal.TargetLevel = "FloorTest";
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
