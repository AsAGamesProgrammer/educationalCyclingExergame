using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAudio : MonoBehaviour {

    //Sound effects audio
    public AudioSource soundEffectsSource;

    public AudioClip btnClickClip;  //Btn click
    public AudioClip spriteChangeClip;  //Horizontal input received
    public AudioClip coinsClip;  //Horizontal input received
    public AudioClip tooExpensiveClip;  //Horizontal input received

    // Use this for initialization
    void Start () {
		
	}

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
}
