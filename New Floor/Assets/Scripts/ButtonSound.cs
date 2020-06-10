using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    AudioClip clickSound;
    [SerializeField]
    AudioMixer mainMixer;

    AudioSource source;
    //Assign values
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = clickSound;
        source.outputAudioMixerGroup = mainMixer.outputAudioMixerGroup;
    }
    //When mouse over item, play sound
    public void OnPointerEnter(PointerEventData eventData)
    {
        source.Play();
    }

}
