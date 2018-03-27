using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarUI : MonoBehaviour {

    AvatarTransfer avatarTransferScript;

    private void Start()
    {
        avatarTransferScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarTransfer>();

    }

    public void OnAdventureBtnClick()
    {
       
        //Money manager
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MoneyManager"));

        //Avatar transfer
        avatarTransferScript.uploadSprites();

        SceneManager.LoadScene("mathsQuestions");
    }
}
