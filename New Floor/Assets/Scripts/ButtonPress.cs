using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private bool machineOn = false;
    public bool IsEnabled { get; set; } = true;
    //Turn on and off based on click
    //Moving button to be pushed in or out
    //Tbd add sound on click
    public void OnMouseDown()
    {
        if (!gameObject.name.Contains("Printer"))
        {
            machineOn = !machineOn;
            if (machineOn)
            {
                transform.Translate(0, 0, -0.01f, Space.Self);
                Debug.Log("Button In");
                //tbd add animation for machine running
            }
            else
            {
                transform.Translate(0, 0, +0.01f, Space.Self);
                Debug.Log("Button Out");
                //tbd stop machine running animation
            }
        }
        else
        {
            if (IsEnabled)
            {
                GetComponent<AudioSource>().Play();
            }
        }

    }
}
