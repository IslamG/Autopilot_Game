using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BossMonitor : InteractableScreen
{
    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    protected GameObject loginScreen;

    protected override void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
        Debug.Log("! ! " + loginScreen);
    }
    protected new void Update()
    {
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused)
        {
            fpc.enabled = true;
            MakeVisible(false);
        }
    }

    //Bring up login screen UI
    public override void SwitchToScreen()
    {
        fpc.enabled = false;
        Debug.Log("Switch to screen from boss ");
        base.SwitchToScreen();
        //this.enabled = false;
    }
}
