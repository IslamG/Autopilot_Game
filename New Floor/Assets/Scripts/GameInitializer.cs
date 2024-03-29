﻿using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour
{
    public static GameInitializer instance;
    static bool created = false;

    [SerializeField]
    cakeslice.Outline outline;
    [SerializeField]
    Animator elevatorAnim;
    [SerializeField]
    GameObject save;

    static GameObject saveIcon;
    //Singleton
    void Awake()
    {
        if (!created)
        {
            //DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            //Destroy(this.gameObject);
        }
        saveIcon = save;
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


        //Load game save
        //LevelTraversal-> Set Active Scene
        //PlayerPosition -> Set Position
        //Puzzle Piece Manager -> SetPuzzles
        //Endings -> Set Flags

        if (currenLvl.Equals("Opening"))
        {
            //Hide mouse when starting game level
            LevelTraversal.TargetLevel = "FloorTest";
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //Debug.Log("d " + outline.GetComponent<cakeslice.Outline>().enabled);
            TipScript tip = Camera.main.GetComponents<TipScript>()[0];
            gameObject.GetComponent<TipsControl>().GenerateTip(tip);
            TipScript tip2 = Camera.main.GetComponents<TipScript>()[1];
            gameObject.GetComponent<TipsControl>().GenerateTip(tip2);
            TipScript tip3 = Camera.main.GetComponents<TipScript>()[2];
            gameObject.GetComponent<TipsControl>().GenerateTip(tip3);
        }
        if (currenLvl.Equals("SubconscienceFloor"))
        {
            //Save when enter Subfloor
            string path = Application.persistentDataPath + "/save_info.sve";
            if (File.Exists(path))
            {
                SaveData data = SaveGame.LoadData();
                Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
                player.x = data.PlayerPosition[0];
                player.y = data.PlayerPosition[1];
                player.z = data.PlayerPosition[2];
            }


            elevatorAnim.Play("ElevatorOpen");
        }
        if (currenLvl.Equals("AirVents"))
        {
            LevelTraversal.TargetLevel = "FloorTest";
        }
        if (currenLvl.Equals("FloorTest"))
        {
            LevelTraversal.TargetLevel = "AirVents";
            TipScript tip = Camera.main.GetComponents<TipScript>()[0];
            gameObject.GetComponent<TipsControl>().GenerateTip(tip);
            TipScript tip2 = Camera.main.GetComponents<TipScript>()[1];
            gameObject.GetComponent<TipsControl>().GenerateTip(tip2);
            TipScript tip3 = Camera.main.GetComponents<TipScript>()[2];
            gameObject.GetComponent<TipsControl>().GenerateTip(tip3);
        }
    }
    static public void ShowIcon(bool flag)
    {
        saveIcon.SetActive(flag);
    }
}
