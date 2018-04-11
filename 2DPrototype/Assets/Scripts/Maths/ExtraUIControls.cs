using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Current elements:
/// *GO BACK button
/// </summary>

    ///TODO
    ///Script which holds avatar picture names

public class ExtraUIControls : MonoBehaviour {

    public GameObject avatar;

	// Use this for initialization
	void Start ()
    {
        avatar = GameObject.FindGameObjectWithTag("MainAvatar");

        //Progress script
        AvatarProgress avatarProgressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();
        avatarProgressScript.ChangeBanner();
    }
	
    //Return to the avatar creation scene
    public void OnGoBackClick()
    {
        //Money manager
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MoneyManager"));
        GameObject.FindGameObjectWithTag("MoneyManager").GetComponent<PlayerMoney>().isNewest = true;

        //Avatar
        DontDestroyOnLoad(avatar);
        SceneManager.LoadScene("avatarCreation", LoadSceneMode.Single);
    }
}
