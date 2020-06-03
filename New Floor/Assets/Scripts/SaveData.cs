using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    private float timeInGame;
    private float[] playerPosition;
    private string levelName;

    public float TimeInGame { get => timeInGame;}
    public float[] PlayerPosition { get => playerPosition;}
    public string LevelName { get => levelName;}

    //Singleton class
    /*void Awake()
    {
        if (instance==null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/
    public void Save()
    {
        timeInGame=TimerController.totalTime;

        Vector3 pos= GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPosition[0] = pos.x;
        playerPosition[1] = pos.y;
        playerPosition[2] = pos.x;
        
        levelName = SceneManager.GetActiveScene().name;
    }
}
