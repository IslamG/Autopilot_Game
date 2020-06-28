using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TurnOnFan : MonoBehaviour
{
    [SerializeField]
    AudioMixer mainMixer;

    private Animator fanimator;
    private bool isOn = false;
    private AudioSource source;

    
    void Start()
    {
        fanimator = gameObject.GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
        source.outputAudioMixerGroup = mainMixer.outputAudioMixerGroup;
    }
    //When object clicked switch animation on/off
    private void OnMouseDown()
    {
        isOn = !isOn;
        if (isOn)
        {
            fanimator.SetBool("fanOn", true);
            //Uncomment when clip is added
            source.Play();
        }
        else
        {
            fanimator.SetBool("fanOn", false);
            //Uncomment when clip is added
            source.Stop();
        }
    }
}
