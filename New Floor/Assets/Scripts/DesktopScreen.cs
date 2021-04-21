using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DesktopScreen : InteractableScreen
{
    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    protected TurnOnScreen screen;

    private void Awake()
    {
        ScreenToShow = this.gameObject;
        screen.OpenUI = this;
    }
    protected new void Update()
    {
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused && IsUp)
        {
            fpc.enabled = true;
            MakeVisible(false);
        }
    }
    public void HideDesktop()
    {
        fpc.enabled = true;
        MakeVisible(false);
        Debug.Log("Mouse hide desktop " + Cursor.lockState);
    }
    public void ShowDesktop()
    {
        fpc.enabled = false;
        MakeVisible(true);
        Debug.Log("Mouse show desktop " + Cursor.lockState);
    }
    /**
     * Once is fully rendered [OnGUI] activate task
     * Placing the activate code in the ShowDesktop method would cause the invoke call
     * to fire before desktop screen is active 
     * i.e. before TaskMenu could add itself as a listener for the task event
    **/
    private void OnGUI()
    {
        if (!isActive)
            Activate();
        if (!Cursor.visible)
        {
            Debug.Log("On GUI Desktop showing mouse");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fpc.enabled = false;
        }
       
    }
}
