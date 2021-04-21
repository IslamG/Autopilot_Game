using UnityEngine;
using UnityEngine.UI;

public class SecutiryPuzzle : Puzzle
{
    public delegate void DelegateFunc();
    DelegateFunc del;

    [SerializeField]
    GameObject[] cameraCones;
    [SerializeField]
    DropSpot usbDrop;
    [SerializeField]
    TipsControl tipsControl;
    [SerializeField]
    Light warningLight;
    [SerializeField]
    AudioSource passwordBeep;
    [SerializeField]
    DoorScript[] doors;
    [SerializeField]
    Task dropUsb;

    private static bool triggered = false, disarmed = false;
    private bool halted = false;
    string password = "12345";
    AudioSource source;

    public bool IsTriggered { get => triggered; }

    protected override void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    public void ShowCones()
    {
        if (!disarmed)
        {
            foreach (GameObject cone in cameraCones)
            {
                cone.SetActive(true);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            ConeTriggered();
        }
    }
    void ConeTriggered()
    {
        if (!disarmed && IsEnabled)
        {
            triggered = true;
            warningLight.gameObject.SetActive(true);
            source.Play();
            usbDrop.gameObject.SetActive(false);
            TipScript tip = gameObject.GetComponents<TipScript>()[0];
            tipsControl.GenerateTip(tip);
            TipScript tip2 = gameObject.GetComponents<TipScript>()[1];
            tipsControl.GenerateTip(tip2);
            foreach (DoorScript door in doors)
            {
                door.SetLock(true);
            }
        }
        
    }
    public void HideCones(GameObject clickedCone)
    {
        foreach (GameObject cone in cameraCones)
        {
            if (cone.Equals(clickedCone))
            {
                cone.SetActive(!cone.activeSelf);
                halted = !halted;
                Debug.Log("SP hide cones called");
                cone.GetComponentInParent<Timer>().Run();
                RawImage timer = clickedCone.GetComponentInParent<CameraConeEntered>().TimerImg;
                timer.gameObject.SetActive(!timer.gameObject.activeSelf);
                if (halted)
                {
                    clickedCone.GetComponentInParent<CameraConeEntered>().Ran = true;
                }
            }      
        }
    }
    public void DisarmAlarm()
    {
        if (dropUsb.IsActive)
        {
            //Debug.Log("Security puzzle disarm pop up: "+gameObject.GetComponent<PopUp>());
            PopUp pop = gameObject.GetComponent<PopUp>();
            pop.ShowPop();
            del = Disarm;
            popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
            popUpGen.gameObject.SetActive(true);
        }
        else
        {
            passwordBeep.Play();
        }
        
    }
    private void Disarm()
    {
            popUpGen.ShowInputField(true);
            Debug.Log("Disarm text to match: " + popUpGen.InputText);
            if (popUpGen.InputText.Equals(password))
            {
                foreach (GameObject cone in cameraCones)
                {
                    cone.SetActive(false);
                }
                foreach (DoorScript door in doors)
                {
                    door.SetLock(false);
                }
                source.Stop();
                warningLight.gameObject.SetActive(false);
                usbDrop.gameObject.SetActive(true);
                disarmed = true;
            }
            else
            {
                passwordBeep.Play();
            }
            popUpGen.ShowInputField(false);
        
    }
}
