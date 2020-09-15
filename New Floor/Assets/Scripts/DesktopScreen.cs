using UnityEngine;

public class DesktopScreen : IinteractableScreen
{
    [SerializeField]
    GameObject crosshair;
    [SerializeField]
    private RenderTexture content;
    public void HideDesktop()
    {
        MakeVisible(false);
    }
    public void ShowDesktop()
    {

        MakeVisible(true);
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        //crosshair.SetActive(false);
        //clear screen and revert back to main camera
        //for viewing login screen
        Debug.Log("Didid");
        //content.DiscardContents();
    }
}
