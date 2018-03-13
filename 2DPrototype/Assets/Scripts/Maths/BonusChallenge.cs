using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusChallenge : MonoBehaviour {

    //GUI elements
    public GameObject bonusPanel;
    public GameObject firstPage;
    public GameObject returnBtn;
    public GameObject startBtn;
    public GameObject questionPage;

    //Indicates if bonus challenge is available
    public bool bonusExists = false;

    //Scripts
    Question questionScript;
    CheckAnswer answerScript;

	// Use this for initialization
	void Start ()
    {
        questionScript = GetComponent<Question>();
        answerScript = GetComponent<CheckAnswer>();
    }
	
	// Update is called once per frame
	void Update ()
    {

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
        //Manage object visibility
        firstPage.SetActive(false);
        returnBtn.SetActive(false);
        startBtn.SetActive(false);
        questionPage.SetActive(true);

        //Request a question
        questionScript.generateBonusAddition();
        answerScript.bonusModeEnabled(true);
    }

}
