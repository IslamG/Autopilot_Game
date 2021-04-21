using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class JeremyMonitor : InteractableScreen, IPathStarter
{

    [SerializeField]
    FirstPersonController fpc;
    [SerializeField]
    protected GameObject loginScreen, arrow;

    PathStarter pathStarter = new PathStarter();

    protected override void Start()
    {
        base.Start();
        ScreenToShow = loginScreen;
        AddSelfAsInvoker();
    }
    protected new void Update()
    {
        if (Input.GetMouseButton(1) && gameObject.activeSelf && !PauseMenu.isPaused && IsUp)
        {
            fpc.enabled = true;
            MakeVisible(false);
        }
    }

    //Bring up login screen UI
    public override void SwitchToScreen()
    {
        fpc.enabled = false;
        Debug.Log("Switch to screen from Jeremy ");
        base.SwitchToScreen();
        //this.enabled = false;
    }

    public override void Activate()
    {
        if (!isActive)
        {
            base.Activate();
            arrow.SetActive(false);
            pathStarter.pathActivated.Invoke(JeremyPath.instance);
        }
        
    }

    public void AddSelfAsInvoker()
    {
        pathStarter.AddSelfAsInvoker();
    }

    public void AddListener(UnityAction<AdventurePath> handler)
    {
        pathStarter.AddListener(handler);
    }
}
