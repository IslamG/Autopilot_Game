using UnityEngine;

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

    private static bool triggered = false;
    string password = "12345";

    public void ShowCones()
    {
        foreach (GameObject cone in cameraCones)
        {
            cone.SetActive(true);
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
        triggered = true;
        warningLight.gameObject.SetActive(true);
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
    public void HideCones(GameObject clickedCone)
    {

        foreach (GameObject cone in cameraCones)
        {
            if (cone.Equals(clickedCone))
                cone.SetActive(!cone.activeSelf);
        }
    }
    public void DisarmAlarm()
    {
        //Debug.Log("Security puzzle disarm pop up: "+gameObject.GetComponent<PopUp>());
        PopUp pop = gameObject.GetComponent<PopUp>();
        pop.ShowPop();
        del = Disarm;
        popUpGen.GetComponent<PopUpGen>().FunctionToDo(del);
        popUpGen.gameObject.SetActive(true);
    }
    private void Disarm()
    {
        popUpGen.DisableInputField(true);
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
            warningLight.gameObject.SetActive(false);
            usbDrop.gameObject.SetActive(true);
        }
        else
        {
            passwordBeep.Play();
        }
        popUpGen.DisableInputField(false);
    }
}
