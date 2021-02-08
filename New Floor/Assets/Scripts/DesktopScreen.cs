using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DesktopScreen : InteractableScreen
{
    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    protected GameObject screen;

    private void Awake()
    {
        ScreenToShow = this.gameObject;
    }
    protected new void Update()
    {
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused)
        {
            fpc.enabled = true;
            MakeVisible(false);
        }
    }
    public void HideDesktop()
    {
        fpc.enabled = true;
        MakeVisible(false);
    }
    public void ShowDesktop()
    {
        MakeVisible(true); 
    }
    /**
     * Once is fully rendered [OnGUI] activate task
     * Placing the activate code in the ShowDesktop method would cause the invoke call
     * to fire before desktop screen is active 
     * i.e. before TaskMenu could add itself as a listener for the task event
    **/
    private void OnGUI()
    {
        if(!isActive)
            Activate();
    }
    protected override void Activate()
    {
        //Activate task based on attached task 
        isActive = true;
        Task task = gameObject.GetComponent<Task>();
        //Invokes task listeners
        task.ActivateTask();
    }
}
