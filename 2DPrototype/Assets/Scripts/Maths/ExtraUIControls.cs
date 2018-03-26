using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Current elements:
/// *GO BACK button
/// </summary>

public class ExtraUIControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGoBackClick()
    {
        SceneManager.LoadScene("avatarCreation");
    }
}
