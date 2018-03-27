using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAvatarSprites : MonoBehaviour {

    GameObject transferObject;
    AvatarTransfer avatarTransferScript;

	// Use this for initialization
	void Start ()
    {
        //Delete all the duplicates
        //Finds all the objects tagged as Money manager
        GameObject[] avatarTransfers = GameObject.FindGameObjectsWithTag("AvatarTransfer");

        //If there are duplicates
        if (avatarTransfers.Length > 1)
        {
            //Delet all the old copies
            foreach (var element in avatarTransfers)
            {
                if (element.GetComponent<AvatarTransfer>().avatarSprites[0] == null)
                    Destroy(element);
            }
        }

        //Find Components
        transferObject = GameObject.FindGameObjectWithTag("AvatarTransfer");
        avatarTransferScript = transferObject.GetComponent<AvatarTransfer>();        
        
        //Special case: beginning of the game
        if (avatarTransferScript.avatarSprites[0] == null)
            return;

        //Interpret
        GameObject mainAvatar = GameObject.FindGameObjectWithTag("MainAvatar");
        for (int i = 0; i < 7; ++i)
        {
            mainAvatar.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = avatarTransferScript.avatarSprites[i];
        }

    }
	
}
