using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioTrace : MonoBehaviour
{
    private Player playerScript;
    private AudioSource playerAudio;
    public AudioClip[] audioClipArray;
    public AudioClip woodSound;
    public AudioClip grassSound;
    public AudioClip metalSound;
    public Slider masterVolume;
    public Slider sfxVolume;
    private float sfxValue;

    void Start()
    {
        //sfxValue = 0.2f;
        masterVolume.value = 0.2f;
        sfxVolume.value = 0.2f;
        sfxValue = sfxVolume.value;
        playerScript = gameObject.GetComponent<Player>();
        playerAudio = GetComponent<AudioSource>();
        masterVolume.onValueChanged.AddListener (delegate {ValueChangeMaster();});
        sfxVolume.onValueChanged.AddListener (delegate {ValueChangeSFX();});
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerAudio.PlayOneShot(RandomAudio(), sfxValue);
        }

        if(playerScript.IsMoving)
        {
            if(playerScript.CurrentFloor == FloorType.Wood)
            {
               playerAudio.PlayOneShot(woodSound, sfxValue);          
            }  

            if(playerScript.CurrentFloor == FloorType.Grass)
            {
                playerAudio.PlayOneShot(grassSound, sfxValue);   
            }

            if(playerScript.CurrentFloor == FloorType.Metal)
            {
                playerAudio.PlayOneShot(metalSound, sfxValue);    
            }
        }
    }

    AudioClip RandomAudio()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }

    public void ValueChangeMaster()
    {
        sfxValue = masterVolume.value;
        sfxVolume.value = masterVolume.value;
    }

    public void ValueChangeSFX()
    {
        sfxValue = sfxVolume.value;
    }


}
