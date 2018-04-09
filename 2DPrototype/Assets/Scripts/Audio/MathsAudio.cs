using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsAudio : MonoBehaviour {


    public AudioSource backgrounSource;
    public AudioClip[] backgroundClips = new AudioClip[3];

	// Use this for initialization
	void Start ()
    {
		
	}
	
	public void ChangeBackgroundMusic(int level)
    {
        backgrounSource.clip = backgroundClips[level];

        backgrounSource.Play();
    }
}
