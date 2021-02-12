using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private bool switchOn = true;
    [SerializeField]
    private Light[] lights;

    private AudioSource source;
    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    public void OnMouseDown()
    {
        //On button clicked reverse state
        switchOn = !switchOn;
        if (switchOn)
        {
            //When switch on, turn on lights associated with button
            foreach (Light bulb in lights)
            {
                bulb.enabled = true;
            }
            //Flip switch
            transform.Rotate(0, +10f, 0, Space.Self);
        }
        //Turn off bulb
        else
        {
            foreach (Light bulb in lights)
            {
                bulb.enabled = false;
            }
            transform.Rotate(0, -10f, 0, Space.Self);
        }
        source.Play();
    }
}
