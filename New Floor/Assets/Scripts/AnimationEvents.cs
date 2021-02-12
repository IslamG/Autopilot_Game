using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AnimationEvents : MonoBehaviour
{
    //HUD task text header animation end
    //Hide text box
    [SerializeField]
    GameObject textDisplay;
    public void DisableTextBox()
    {
        textDisplay.SetActive(false);
    }

    //Tutorial basic intro animation switch off
    //Turn on normal HUD
    [SerializeField]
    Canvas introCanvas, hudCanvas;
    [SerializeField]
    Camera walkThroughCam, fpCam;
    public void SwitchTutorialBasic()
    {
        hudCanvas.gameObject.SetActive(true);
        introCanvas.gameObject.SetActive(false);
        walkThroughCam.gameObject.GetComponent<Animator>().Play("TurtorialIntro2");
    }
    [SerializeField]
    BasicTutorial basicTutorial;
    public void TutorialStart()
    {
        basicTutorial.First();
    }
    public void ViewMotion()
    {
        walkThroughCam.gameObject.GetComponent<CameraLook>().enabled = true;
        walkThroughCam.gameObject.GetComponent<Animator>().enabled = false;
    }
    public void CameraSwitch()
    {
        fpCam.gameObject.SetActive(true);
        walkThroughCam.gameObject.SetActive(false);
        fpCam.gameObject.GetComponentInParent<FirstPersonController>().enabled = true;
    }
}
