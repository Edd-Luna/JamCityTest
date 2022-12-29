using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    private AudioTrace AudioScript;
    private AudioSource musicAudio;
    public Slider musicVolume;
    private float musicValue;

    void Start()
    {
        //musicValue = 0.2f;
        musicVolume.value = 0.2f;
        musicAudio = GetComponent<AudioSource>();
        musicVolume.onValueChanged.AddListener (delegate {ValueChangeMusic();});
        AudioScript = GameObject.Find("Player").GetComponent<AudioTrace>();
        AudioScript.masterVolume.onValueChanged.AddListener (delegate {ValueChangeMaster();});
        musicAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //musicValue = AudioScript.masterVolume.value;
        musicAudio.volume = musicValue;
    }

    public void ValueChangeMaster()
    {
        musicValue = AudioScript.masterVolume.value;
        musicVolume.value = AudioScript.masterVolume.value;
    }

    public void ValueChangeMusic()
    {
        musicValue = musicVolume.value;
    }
}
