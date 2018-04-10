using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsAudio : MonoBehaviour {

    //Audio
    public AudioSource backgrounSource;
    public AudioClip[] backgroundClips = new AudioClip[3];

    //Scripts
    AvatarProgress progressScript;

	// Use this for initialization
	void Start ()
    {
        //Find script
        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();

        ChangeBackgroundMusic(progressScript.level);
    }
	
	public void ChangeBackgroundMusic(int level)
    {
        backgrounSource.clip = backgroundClips[level];

        backgrounSource.Play();
    }
}
