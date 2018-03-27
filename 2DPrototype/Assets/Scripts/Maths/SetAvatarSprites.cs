using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAvatarSprites : MonoBehaviour {

    GameObject transferObject;
    AvatarTransfer avatarTransferScript;

	// Use this for initialization
	void Start ()
    {
        //Find Components
        transferObject = GameObject.FindGameObjectWithTag("AvatarTransfer");
        avatarTransferScript = transferObject.GetComponent<AvatarTransfer>();

        //Interpret
        GameObject mainAvatar = GameObject.FindGameObjectWithTag("MainAvatar");
        for (int i = 0; i < 7; ++i)
        {
            mainAvatar.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = avatarTransferScript.avatarSprites[i];
        }

    }
	
}
