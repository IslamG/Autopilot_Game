using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BasicTutorial : MonoBehaviour
{
    [SerializeField]
    Camera walkThroughCam;
    [SerializeField]
    TaskMenu taskMenu;
    [SerializeField]
    GameObject deskPrefab;
    [SerializeField]
    FirstPersonController fpc;

    int segment = 0;
    CheckpointPivot checkManager, checkCamera1, checkMenu;
    Animator animCamera1;

    public bool InputEnabled { get; set; } = false;

    private void Start()
    {
        checkManager = gameObject.GetComponent<CheckpointPivot>();
        checkCamera1 = walkThroughCam.GetComponent<CheckpointPivot>();
        checkMenu = taskMenu.gameObject.GetComponent<CheckpointPivot>();
        animCamera1 = walkThroughCam.GetComponent<Animator>();
        Debug.Log("BT InputEnaled: " + InputEnabled);

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
        if (segment == 6 && deskPrefab.activeSelf && InputEnabled)
        {
            Sixth();
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
        taskMenu.gameObject.SetActive(true);
        Debug.Log("BT TaskMenu :" + taskMenu.gameObject.activeSelf);
        Debug.Log("Done third BT");
        segment++;
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
        InputEnabled = false;
        walkThroughCam.GetComponent<CameraLook>().enabled = true;
        deskPrefab.SetActive(true);
        segment++;
    }
    private void Sixth()
    {
        InputEnabled = false;
        fpc.gameObject.SetActive(true);
        walkThroughCam.gameObject.SetActive(false);
        segment++;
    }
}
