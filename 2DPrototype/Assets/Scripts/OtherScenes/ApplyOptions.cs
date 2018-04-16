using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplyOptions : MonoBehaviour {

    //Find options manager
    OptionsScript optionsManager;

    //Toggles
    public Toggle musicToggle;
    public Toggle sfxToggle;

	// Use this for initialization
	void Start ()
    {
        optionsManager = GameObject.FindGameObjectWithTag("Options").GetComponent<OptionsScript>();
	}
	
    public void OnApplyClick()
    {
        optionsManager.MusicOn = musicToggle.isOn;
        optionsManager.SFXOn = sfxToggle.isOn;

        //Transfer to the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
