using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using cakeslice;
using System;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    public static GameInitializer instance;
    static bool created = false;

    [SerializeField]
    cakeslice.Outline outline;
    //Singleton
    void Awake()
    {
        if (!created)
        {
            created = true;
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }
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
            Debug.Log("d " + outline.GetComponent<cakeslice.Outline>().enabled);
            //outline.enabled = true;
        }
        if (currenLvl.Equals("SubconscienceFloor"))
        {
            SaveData data = SaveGame.LoadData();
            Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
            player.x=data.PlayerPosition[0];
            player.y=data.PlayerPosition[1];
            player.z=data.PlayerPosition[2];

            Console.WriteLine("p el: " + player);
        }
    }
}
