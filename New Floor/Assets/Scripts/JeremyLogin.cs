using UnityEngine;

public class JeremyLogin : LoginScreen
{
    [SerializeField]
    protected GameObject desktopScreen;

    protected override void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
    }

    public override void Login()
    {
        if (isUnlocked)
        {
            if (taskToRemove != null)
            {
                foreach (Task task in taskToRemove)
                {
                    taskMenu.RemoveTaskFromList(task);
                }
            }
            //Activate();
            MakeVisible(false);
            if (desktopScreen != null)
            {
                desktopScreen.SetActive(true);
                desktopScreen.GetComponent<DesktopScreen>().ShowDesktop();
            }
            //DisableScreen();
            this.enabled = false;
        }
    }

}
