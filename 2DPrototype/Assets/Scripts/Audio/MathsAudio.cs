using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LIST OF AUDIO SOURCES
/// BACKGROUND - background music
/// SOUND EFFECTS - btn click, semi-open chest, fully open chest
/// 
/// </summary>


public class MathsAudio : MonoBehaviour {

    //Background audio
    public AudioSource backgrounSource;
    public AudioClip[] backgroundClips = new AudioClip[3];

    //Sound effects audio
    public AudioSource soundEffectsSource;

    public AudioClip btnClickClip;  //Btn click
    public AudioClip fireworksClip;  //Fireworks
    public AudioClip correctAnswer;  //Chest opening

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

    public void PlayFireworks()
    {
        soundEffectsSource.clip = fireworksClip;
        soundEffectsSource.Play();
    }

    public void PlayCorrectAnswer()
    {
        soundEffectsSource.clip = correctAnswer;
        soundEffectsSource.Play();
    }


    //------------BACKGROUND MUSIC-------------
    public void ChangeBackgroundMusic(int level)
    {
        backgrounSource.clip = backgroundClips[level];

        backgrounSource.Play();
    }
}
