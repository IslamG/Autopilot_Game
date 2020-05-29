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
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clickSound;
        source.outputAudioMixerGroup = mainMixer.outputAudioMixerGroup;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered " + gameObject.name);
        source.Play();
    }

}
