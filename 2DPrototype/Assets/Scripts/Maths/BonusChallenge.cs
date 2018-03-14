using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusChallenge : MonoBehaviour {

    //GUI elements
    public GameObject bonusPanel;
    public GameObject firstPage;
    public GameObject questionPage;
    public GameObject losePage;
    public GameObject winPage;

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

    //Lose
    public Text correctAnswer;

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
                //Stop timer
                currentTime = 0;
                countdownEnabled = false;

                //Show lose page
                enableLosePage();
                //Show correct answer
                correctAnswer.text = answerScript.getCorrectAnswer().ToString();
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
        if (bonusExists)
        {
            bonusPanel.SetActive(true);
            enableFirstPage();
        }
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
        enableQuestionPage();

        //Request a question
        questionScript.generateBonusAddition();
        answerScript.bonusModeEnabled(true);

        //Timer
        currentTime = maximumTime;
        countdownEnabled = true;
    }

    //--------------HELPERS
    private void enableFirstPage()
    {
        firstPage.SetActive(true);
        questionPage.SetActive(false);
        losePage.SetActive(false);
        winPage.SetActive(false);
    }

    private void enableQuestionPage()
    {
        firstPage.SetActive(false);
        questionPage.SetActive(true);
        losePage.SetActive(false);
        winPage.SetActive(false);
    }

    private void enableLosePage()
    {
        firstPage.SetActive(false);
        questionPage.SetActive(false);
        losePage.SetActive(true);
        winPage.SetActive(false);
    }

    //Called from the check answer script
    public void enableWinPage()
    {
        firstPage.SetActive(false);
        questionPage.SetActive(false);
        losePage.SetActive(false);
        winPage.SetActive(true);
    }

}
