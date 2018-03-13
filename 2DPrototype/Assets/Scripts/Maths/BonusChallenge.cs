using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusChallenge : MonoBehaviour {

    //GUI elements
    public GameObject bonusPanel;

    //Indicates if bonus challenge is available
    public bool bonusExists = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Set panel to be visible
    public void ShowPanel()
    {
        if(bonusExists)
            bonusPanel.SetActive(true);
    }

    //Set panel to be invisible and return to the game
    public void HidePanel()
    {
        bonusPanel.SetActive(false);
    }

    //Start challenge
    public void StartChallenge()
    {

    }
}
