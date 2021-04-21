using UnityEngine;

public class JeremyLogin : LoginScreen
{
    [SerializeField]
    protected GameObject desktopScreen;
    [SerializeField]
    TurnOnScreen onScreen;

    protected override void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
        //onScreen.OpenUI = this;
    }

    public override void Login()
    {
        if (isUnlocked && !isSolved)
        {
            if (taskToRemove != null)
            {
                foreach (Task task in taskToRemove)
                {
                    if(task.IsActive)
                        taskMenu.RemoveTaskFromList(task);
                }
            }
            Solve();
            MakeVisible(false);
            onScreen.OpenUI = desktopScreen.GetComponent<InteractableScreen>();
            if (desktopScreen != null)
            {
                desktopScreen.SetActive(true);
                desktopScreen.GetComponent<DesktopScreen>().ShowDesktop();
            }
            //DisableScreen();
            //onScreen.OpenUI = desktopScreen.GetComponent<InteractableScreen>();
            gameObject.SetActive(false);
            this.enabled = false;
            
        }
    }

}
