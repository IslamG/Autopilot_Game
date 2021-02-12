using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField]
    private Animator anim, lvlNum;
    [SerializeField]
    AudioSource sound;
    private static bool doorOpen = false, isPressed = false;
    [SerializeField]
    GameObject arrowUp, arrowDown;

    //Field to control responsiveness for other scripts
    public bool IsEnabled { get; set; } = true;

    private void Update()
    {
        //We clicked the button and are now waiting for the sfx and animation to finish
        if (isPressed)
        {
            //Update keeps checking for the sound clip to stop playing
            if (!sound.isPlaying)
            {
                //When the clip is finished take action and be receptive to new clicks
                PressAction();
                isPressed = false;
            }
        }
    }
    //When elevator button clicked
    void OnMouseDown()
    {
        if (IsEnabled)
        {
            //When closed, allow to click, and play sound and animations for calling the elevator
            if (!doorOpen)
            {
                isPressed = true;
                sound.Play();
                lvlNum.Play("LevelSwitch");
                //Determine which arrow animation to play based on click source
                if (gameObject.name.Contains("Up"))
                {
                    arrowUp.SetActive(true);
                    arrowUp.GetComponent<Animation>().Play();
                }
                else
                {
                    arrowDown.SetActive(true);
                    arrowDown.GetComponent<Animation>().Play();
                }
            }
            //The door is already open 
            //no need for elevator call sequence
            //just behave on click normally
            else
            {
                PressAction();
            }
        }

    }
    //Actions to take when elevator button clicked
    void PressAction()
    {
        //Stop arrow animation and hide
        arrowUp.GetComponent<Animation>().Stop();
        arrowDown.GetComponent<Animation>().Stop();
        arrowUp.SetActive(false);
        arrowDown.SetActive(false);
        //Switch door states
        doorOpen = !doorOpen;
        //Play correct animation for state
        //And push button in or out accordingly
        if (doorOpen)
        {
            anim.Play("ElevatorOpen");
            transform.Translate(-0.01f, 0, 0, Space.Self);
        }
        else
        {
            anim.Play("ElevatorClose");
            transform.Translate(+0.01f, 0, 0, Space.Self);
        }
    }
}
