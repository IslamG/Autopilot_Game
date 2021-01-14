using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningLogin : LoginScreen
{
    protected new void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
    }
    [SerializeField]
    private Image fadeBlack;
    public override void Login()
    {
        Debug.Log("Trying to log in");
        if (isUnlocked)
        {
            taskMenu.RemoveTaskFromList(task);
            gameObject.GetComponentsInParent<InteractableScreen>()[0].MakeVisible(false);
            //Trigger fade out of scene
            fadeBlack.gameObject.SetActive(true);
            fadeBlack.GetComponent<FadeBlack>().Fade();
            Debug.Log("Trying to log in2");
        }
    }
    protected override void Activate()
    {
        Debug.Log("Login trying to activate from " + gameObject.name);
    }
}
