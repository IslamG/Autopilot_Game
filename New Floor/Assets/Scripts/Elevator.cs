using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public static Elevator instance;
    static bool created = false;
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

    [SerializeField]
    private Animator elevatorAnimator, lightAnimator;
    [SerializeField]
    private GameObject doorAnim, player;

    Timer animationTimer, btnTimer;
    private void Start()
    {
        animationTimer = gameObject.AddComponent<Timer>();
        animationTimer.Duration = 5;
    }
    private void Update()
    {
        if (animationTimer.Finished)
        {
            //Stop animations and open elevator doors
            lightAnimator.SetBool("isMoving", false);
            elevatorAnimator.Play("ElevatorOpen");
            if (ElevatorSequence.IsUnlocked)
            {
                //If secrete password entered, save game
                //and load in secret ending 
                Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
                SceneManager.LoadScene("SubconscienceFloor");
                SaveGame.SaveData();
                //SceneManager.UnloadSceneAsync("FloorTest");
                //Resources.UnloadUnusedAssets();
            }
            if (SceneManager.GetActiveScene().name.Equals("SubconscienceFloor"))
            {
                SceneManager.LoadScene("FloorTest");
                SaveGame.SaveData();
            }
        }
    }
    public void SequenceAction()
    {
        //Close elevator doors and play descent animation
        elevatorAnimator.Play("ElevatorClose");
        elevatorAnimator.Play("ElevatorRattle");
        lightAnimator.SetBool("isMoving", true);
        //Fake a transition to new location
        FakeTransition();
    }
    private void FakeTransition()
    {
        //Close keypad
        if(!SceneManager.GetActiveScene().name.Equals("SubconscienceFloor"))
            GetComponentInChildren<ElevatorKeypad>().LeaveKeypad();
        animationTimer.Run();
    }
}
