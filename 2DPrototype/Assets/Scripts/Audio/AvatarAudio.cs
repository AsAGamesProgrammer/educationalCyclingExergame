using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAudio : MonoBehaviour {

    //Sound effects audio
    public AudioSource soundEffectsSource;

    public AudioClip btnClickClip;  //Btn click
    public AudioClip spriteChangeClip;  //Horizontal input received

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
}
