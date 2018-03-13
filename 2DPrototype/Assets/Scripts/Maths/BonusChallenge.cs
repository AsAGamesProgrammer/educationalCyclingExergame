using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusChallenge : MonoBehaviour {

    //GUI elements
    public GameObject bonusPanel;
    public GameObject firstPage;
    public GameObject questionPage;

    //Timer
    public Text timerText;          //timer text
    public float maximumTime = 30;    //Constant
    float currentTime;                //How muh time is left
    bool countdownEnabled = false;  //Is the countdown on

    //Indicates if bonus challenge is available
    public bool bonusExists = false;

    //Scripts
    Question questionScript;
    CheckAnswer answerScript;

	// Use this for initialization
	void Start ()
    {
        //Get scripts
        questionScript = GetComponent<Question>();
        answerScript = GetComponent<CheckAnswer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(countdownEnabled)
        {
            if(currentTime<=0)
            {
                currentTime = 0;
                Debug.Log("GameOver");
            }

            //Decrease time
            currentTime -= Time.deltaTime;

            //Update label
            timerText.text = currentTime.ToString();
        }
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
        questionPage.SetActive(true);

        //Request a question
        questionScript.generateBonusAddition();
        answerScript.bonusModeEnabled(true);

        //Timer
        currentTime = maximumTime;
        countdownEnabled = true;
    }

}
