using UnityEngine;

public class BossLogin : LoginScreen
{
    [SerializeField]
    protected GameObject desktopScreen;

    protected override void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
        password = "5678";
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
                desktopScreen.GetComponent<SecurityScreen>().ShowDesktop();
            }
            //DisableScreen();
            this.enabled = false;
        }
    }
}
