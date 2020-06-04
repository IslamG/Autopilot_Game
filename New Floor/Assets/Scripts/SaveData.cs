using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData 
{

    private float timeInGame;
    private float[] playerPosition;
    private string levelName;

    public float TimeInGame { get => timeInGame;}
    public float[] PlayerPosition { get => playerPosition;}
    public string LevelName { get => levelName;}

    public SaveData()
    {
        timeInGame=TimerController.totalTime;

        Vector3 pos= GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPosition = new float[3];
        playerPosition[0] = pos.x;
        playerPosition[1] = pos.y;
        playerPosition[2] = pos.x;
        
        levelName = SceneManager.GetActiveScene().name;
    }
}
