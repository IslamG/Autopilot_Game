using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorSequence : MonoBehaviour
{
    public static ElevatorSequence instance;
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
    private GameObject elevator;

    private const string sequence = "11513249";
    private static string input = "";
    private static bool isUnlocked = false;

    private Timer timer;
    private bool finishedWaiting = false, startedCounting = false;
    private int elapsedTime = 0;
    private Coroutine theWait;

    public static bool IsUnlocked { get => isUnlocked; }

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
    }
    public void Sequence(Button btn)
    {
        //Get input and check if correct sequence
        input += btn.GetComponentInChildren<TMP_Text>().text;
        Debug.Log("clicked: " + input);
        //Start count from button press
        StartCoroutine(Check());
    }
    //Compare if unlocked
    private IEnumerator Check()
    {
        //Wait for 7 seconds
        //Used for allowing more input before transitioning real or fake
        yield return new WaitForSecondsRealtime(7f);

        //if user input the correct button sequence unlock route
        if (sequence.Equals(input))
        {
            isUnlocked = true;
        }
        elevator.GetComponent<Elevator>().SequenceAction();
    }
    //Upon exit from button window reset input
    public void Reset()
    {
        Debug.Log("Reset");
        input = "";
        StopCoroutine(Check());
    }
}
