using UnityEngine;
using UnityEngine.UI;

public class OpeningLogin : LoginScreen
{
    protected override void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
        Debug.Log("Screen to show in opening loging " + ScreenToShow);
    }
    [SerializeField]
    private Image fadeBlack;
    public override void Login()
    {
        Debug.Log("Trying to log in");
        if (isUnlocked)
        {
            if (taskToRemove != null)
            {
                foreach (Task task in taskToRemove)
                {
                    taskMenu.RemoveTaskFromList(task);
                }
            }

            gameObject.GetComponentsInParent<InteractableScreen>()[0].MakeVisible(false);
            //Trigger fade out of scene
            fadeBlack.gameObject.SetActive(true);
            fadeBlack.GetComponent<FadeBlack>().Fade();
            Debug.Log("Trying to log in2");
        }
    }
}
