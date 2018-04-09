using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {

    public GameObject[] backgrounds = new GameObject[3];

    AvatarProgress progressScript;

	// Use this for initialization
	void Start ()
    {
        //Progress script
        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();

        ChangeLevel(progressScript.level);
    }
	

    public void ChangeLevel(int level)
    {
        foreach (var background in backgrounds)
            background.SetActive(false);

        backgrounds[level].SetActive(true);

    }
}
