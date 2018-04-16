﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAudio : MonoBehaviour {

    //Sound effects audio
    public AudioSource soundEffectsSource;
    public AudioSource soundEffectsSource2; //Used for longer sounds, such as change applied

    public AudioClip btnClickClip;      //Btn click
    public AudioClip spriteChangeClip;  //Horizontal input received
    public AudioClip coinsClip;         //Item was bought
    public AudioClip tooExpensiveClip;  //Cant buy an item
    public AudioClip changeAppliedClip; //Change applied to the avatar

    //------------SOUND EFFECTS-------------
    //Btn click
    public void PlayBtnClick()
    {
        soundEffectsSource.clip = btnClickClip;
        soundEffectsSource.Play();
    }

    //Horizontal input
    public void PlaySpriteChange()
    {
        soundEffectsSource.clip = spriteChangeClip;
        soundEffectsSource.Play();
    }

    //Item bought
    public void PlayCoins()
    {
        soundEffectsSource.clip = coinsClip;
        soundEffectsSource.Play();
    }

    //Cant buy an item
    public void PlayTooExpensive()
    {
        soundEffectsSource.clip = tooExpensiveClip;
        soundEffectsSource.Play();
    }

    //Change applied to the avatar
    public void PlayChangeApplied()
    {
        soundEffectsSource2.clip = changeAppliedClip;
        soundEffectsSource2.Play();
    }
}
