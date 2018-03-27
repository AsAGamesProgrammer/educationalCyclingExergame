using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarTransfer : MonoBehaviour {

    public Sprite[] avatarSprites = new Sprite[7];

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
    }
	
	public void uploadSprites()
    {
        GameObject avatar = GameObject.FindGameObjectWithTag("MainAvatar");

        //Only the first seven elements are important
        for (int i = 0; i < 7; ++i)
        {
            avatarSprites[i] = avatar.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
        }

    }
}
