using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SecurityScreen : InteractableScreen
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
}
