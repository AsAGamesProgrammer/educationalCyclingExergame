using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsAudio : MonoBehaviour {

    //Background audio
    public AudioSource backgrounSource;
    public AudioClip[] backgroundClips = new AudioClip[3];

    //Sound effects audio
    public AudioSource soundEffectsSource;

    public AudioClip btnClickClip;  //Btn click

    //Scripts
    AvatarProgress progressScript;

	// Use this for initialization
	void Start ()
    {
        //Find script
        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();

        ChangeBackgroundMusic(progressScript.level);
    }

    //------------SOUND EFFECTS-------------
    public void PlayBtnClick()
    {
        soundEffectsSource.clip = btnClickClip;
        soundEffectsSource.Play();
    }


    //------------BACKGROUND MUSIC-------------
    public void ChangeBackgroundMusic(int level)
    {
        backgrounSource.clip = backgroundClips[level];

        backgrounSource.Play();
    }
}
