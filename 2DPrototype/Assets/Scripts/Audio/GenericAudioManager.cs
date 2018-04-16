using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAudioManager : MonoBehaviour {

    //Background source
    public AudioSource backgroundSource;

    //Sound effects audio
    public AudioSource soundEffectsSource;

    //Clip
    public AudioClip btnClickClip;      //Btn click

    // Use this for initialization
    void Start ()
    {
        OptionsScript optionsManager = GameObject.FindGameObjectWithTag("Options").GetComponent<OptionsScript>();

        //Disable music if needed
        if (!optionsManager.MusicOn)
            backgroundSource.gameObject.SetActive(false);

        if (!optionsManager.SFXOn)
        {
            soundEffectsSource.gameObject.SetActive(false);
        }
    }

    //Btn click
    public void PlayBtnClick()
    {
        soundEffectsSource.clip = btnClickClip;
        soundEffectsSource.Play();
    }
}
