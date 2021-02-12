using UnityEngine;

public class CameraIdle : MonoBehaviour
{
    [SerializeField]
    private Canvas hud;

    float timeOut = 5.0f; // Time Out Setting in Secounds
    private float timeOutTimer = 0.0f;
    private Animator anim;
    private Camera mainCam, idleCam;
    private Quaternion camRot;

    //Initialize variables
    private void Start()
    {
        anim = transform.Find("IdleCamera").GetComponent<Animator>();
        mainCam = Camera.main;
        idleCam = transform.Find("IdleCamera").GetComponent<Camera>();
    }
    void Update()
    {
        //Increase time without input
        if (!TaskMenu.IsDisplayed)
        {
            timeOutTimer += Time.deltaTime;
        }
        //Mouse moved, reset timer
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            DisableIdle();
        }
        //If any input detected disable idle state
        else if (Input.anyKey)
        {
            DisableIdle();
        }
        //Mouse inactivity period has occured
        if (timeOutTimer > timeOut)
        {
            //Face camera forward and start idle animation
            if (!idleCam.enabled)
                idleCam.transform.rotation = Quaternion.LookRotation(idleCam.transform.up);
            anim.SetBool("isActive", false);
            mainCam.enabled = false;
            idleCam.enabled = true;
            //Hide HUD
            hud.gameObject.SetActive(false);
        }
    }
    //Stop idle animation and show hidden HUD
    private void DisableIdle()
    {
        timeOutTimer = 0.0f;
        anim.SetBool("isActive", true);
        mainCam.enabled = true;
        idleCam.enabled = false;
        hud.gameObject.SetActive(true);
    }
}