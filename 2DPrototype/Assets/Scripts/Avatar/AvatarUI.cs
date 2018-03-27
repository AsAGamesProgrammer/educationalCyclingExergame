using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarUI : MonoBehaviour {

    AvatarTransfer avatarTransferScript;

    public void OnAdventureBtnClick()
    {
        avatarTransferScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarTransfer>();

        //Money manager
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MoneyManager"));

        //Avatar transfer
        avatarTransferScript.uploadSprites();

        SceneManager.LoadScene("mathsQuestions");
    }
}
