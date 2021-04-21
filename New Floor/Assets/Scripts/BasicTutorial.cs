using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BasicTutorial : MonoBehaviour
{
    [SerializeField]
    Camera walkThroughCam;
    [SerializeField]
    TaskMenu taskMenu;
    [SerializeField]
    GameObject deskPrefab, dimPanel, crossHair, arrow, arrowUI, noteUI,
        taskUSB, monitor;
    [SerializeField]
    FirstPersonController fpc;

    int segment = 0;
    bool called = false;
    CheckpointPivot checkManager, checkCamera1, checkMenu, checkDesk, checkArrow,
        checkMonitor;
    Animator animCamera1;
    Task firstTask;
    DropSpot dropSpot;
    public bool InputEnabled { get; set; } = false;

    private void Start()
    {
        checkManager = gameObject.GetComponent<CheckpointPivot>();
        checkCamera1 = walkThroughCam.GetComponent<CheckpointPivot>();
        checkMenu = taskMenu.gameObject.GetComponent<CheckpointPivot>();
        checkDesk = deskPrefab.gameObject.GetComponent<CheckpointPivot>();
        checkArrow = arrow.GetComponent<CheckpointPivot>();
        checkMonitor = monitor.GetComponent<CheckpointPivot>();
        animCamera1 = walkThroughCam.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        crossHair.SetActive(false);
        Debug.Log("BT InputEnaled: " + InputEnabled);
        firstTask = deskPrefab.GetComponent<Task>();
        dropSpot = taskUSB.GetComponent<DropItem>().TargetSpot[0];
    }

    private void Update()
    {
        //Debug.Log("BT Segment: " + segment);
        if (Input.anyKey && InputEnabled)
        {
            if (segment == 1)
            {
                segment++;
            }
        }
        if (segment == 2)
        {
            Second();
        }
        if (segment == 3)
        {

            if ((Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
                Third();
        }
        if (segment == 4 && Input.GetKey(KeyCode.M) && InputEnabled)
        {
            Fourth();
        }
        if (segment == 5 && Input.GetKey(KeyCode.M) && InputEnabled)
        {
            Fifth();
        }
        if (segment == 6)
        {
            if ((Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
                Sixth();
        }
        if (segment == 7 && !called)
        {
            StartCoroutine(Seventh());
        }
        if (segment == 8 && Input.anyKey)
        {
            Eighth();
        }
        if(segment==11 && Input.GetMouseButton(1))
        {
            Eleventh();
        }
        if(segment==12 && !dropSpot.gameObject.activeSelf)
        {
            Twelfth();
        }
    }
    public void First()
    {
        InputEnabled = false;
        checkManager.StartHintDisplay();
        segment++;
    }
    private void Second()
    {
        InputEnabled = false;
        animCamera1.Play("TutorialIntro3");
        segment++;
    }
    private void Third()
    {
        InputEnabled = false;
        checkCamera1.StartHintDisplay();
        crossHair.SetActive(true);
        Debug.Log("Done third BT");
        segment++;
        StartCoroutine(DimElementsBut(taskMenu.gameObject, 12));
    }
    private void Fourth()
    {
        InputEnabled = false;
        walkThroughCam.GetComponent<CameraLook>().enabled = false;
        checkMenu.StartHintDisplay();
        segment++;
    }
    private void Fifth()
    {
        dimPanel.SetActive(false);
        //InputEnabled = false;
        walkThroughCam.GetComponent<CameraLook>().enabled = true;
        deskPrefab.SetActive(true);
        segment++;
        Debug.Log("Segment at " + segment);
    }
    private void Sixth()
    {
        //InputEnabled = false;
        fpc.enabled = true;
        fpc.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        fpc.CanMove = false;
        Debug.Log("Sixth activated fpc");
        walkThroughCam.gameObject.SetActive(false);
        Debug.Log("Sixth hidden look cam");
        arrow.SetActive(true);
        Debug.Log("Sixth arrow cam shown");
        arrowUI.SetActive(true);
        Debug.Log("Sixth arrow UI activated");
        dimPanel.SetActive(true);
        segment++;//=7th
        Debug.Log("Sixth segment = 7");
        checkArrow.StartHintDisplay();
        Debug.Log("Sixth arrow check called");
        //StartCoroutine(DimElementsBut(arrowUI, 3));
    }
    private IEnumerator Seventh()
    {
        //Debug.Log("Jumped the shark, i'm already in 7th");
        called = true;
        yield return new WaitForSeconds(6);
        GameObject dropLocation=gameObject.transform.GetChild(0).gameObject;
        dropLocation.SetActive(true);
        firstTask.ActivateTask();
        TargettingBehavior targetting = arrow.GetComponentInChildren<TargettingBehavior>();
        targetting.target=dropLocation.transform;
        targetting.enabled = true;
        //dimPanel.SetActive(true);
        checkDesk.StartHintDisplay();
        Canvas canvas = arrowUI.transform.parent.GetComponent<Canvas>();
        canvas.sortingOrder = 0;
        StartCoroutine(DimElementsBut(taskMenu.gameObject, 3));
        segment++;//=8th
    }
    private void Eighth()
    {
        fpc.CanMove = true;
        dimPanel.SetActive(false);
        
        segment++;//=9th
    }
    private void Tenth()
    {
        TipsControl control = gameObject.GetComponent<TipsControl>();
        TipScript tip = gameObject.GetComponent<TipScript>();
        control.GenerateTip(tip);
        checkMonitor.StartHintDisplay();
        //StartCoroutine(DimElementsBut(noteUI, 1));
        segment++;//= 11th
        Debug.Log("In tenth segment= " + segment);
    }
    private void Eleventh()
    {
        Debug.Log("In eleventh");
        dimPanel.SetActive(false);
        Task task = taskUSB.GetComponent<Task>();
        task.ActivateTask();
        dropSpot.gameObject.SetActive(true) ;
        segment++;
    }
    private void Twelfth()
    {
        Debug.Log("Called Twelve");
        segment++;
    }
    IEnumerator DimElementsBut(GameObject highlightObj, int duration)
    {
        Debug.Log("Dimmin pre wait");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(duration);
        //Get sibling index returns the index just above itself
        int highlightIndex = highlightObj.transform.GetSiblingIndex();
        Debug.Log("highlight index " + highlightIndex);
        Debug.Log("Dim index " + dimPanel.transform.GetSiblingIndex());
        dimPanel.transform.SetSiblingIndex(highlightIndex-1);
        dimPanel.SetActive(true);
        Debug.Log("Dim index " + dimPanel.transform.GetSiblingIndex());
    }
    //Ninth Segment
    bool once = false;
    private void OnTriggerEnter(Collider other)
    {
        firstTask.IsCompleted = true;
        taskMenu.RemoveTaskFromList(firstTask);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        if (!once)
        {
            segment++;//=10th change?
            once = true;
        }
        
        Tenth();
    }
}
