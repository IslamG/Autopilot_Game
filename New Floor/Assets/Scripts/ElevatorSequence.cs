using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorSequence : MonoBehaviour
{
    private const string sequence="11513249";
    private static string input = "";
    private static bool isUnlocked= false;
    public Animator elevatorAnimator, lightAnimator;
    public GameObject doorAnim, elevator, player;
    private Timer timer;
    private void Start()
    {
        //Create and set the duration of descent
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5;
    }
    public void Sequence(Button btn)
    {
        //Get input and check if correct sequence
        input += btn.GetComponentInChildren<TMP_Text>().text;
        Debug.Log("clicked: "+input);
        Check();
    }
    private void Check()
    {
        //if user input the correct button sequence unlock route
        if (sequence.Equals(input))
        {
            isUnlocked = true;
        }
        //if unlocked, take to new level
        if (isUnlocked)
        {
            //Close elevator doors and play descent animation
            //anim.SetBool("isClosed", true);
            elevatorAnimator.Play("ElevatorClose");

            // (!doorAnim.GetComponent<Animation>().IsPlaying("ElevatorClose"))
            //{
              elevatorAnimator.Play("ElevatorDescend");
              lightAnimator.SetBool("isMoving", true);
            //Fake a transition to new location
            FakeTransition();
            //}
            //Allow descent animation loop until timer finished
            if (timer.Finished)
            {
                Debug.Log("Timer finished");
                //Stop animations and open elevator doors
                lightAnimator.SetBool("isMoving", false);
                elevatorAnimator.Play("ElevatorOpen");
            }
        }
    }
    //Upon exit from button window reset input
    public void Reset()
    {
        input = "";
    }
    private void FakeTransition()
    {
        //Close keypad
        elevator.GetComponentInChildren<ElevatorKeypad>().LeaveKeypad();
        //Turn elevator and player around
        elevator.transform.localScale = new Vector3(transform.localScale.x*- 1.0f, transform.localScale.y, transform.localScale.z);
        player.transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        timer.Run();
    }
}
