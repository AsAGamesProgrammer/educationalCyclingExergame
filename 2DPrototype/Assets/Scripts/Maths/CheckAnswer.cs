using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour {

    public Question questionScript;
    float correctAnswer = 56;
    float enteredAnswer;

    public Chests chestScript;

    //Input fields
    public InputField regularField;
    public InputField bonusField;
    InputField inputField;

    //Money
    int regularReward = 10;
    int bonusReward = 50;
    int reward;
    public Text balanceText;

    //Money script
    PlayerMoney moneyScript;

    //Modes
    bool bonusMode = false;

    //Bonus challenge script
    BonusChallenge bonusChallengeScript;

	// Use this for initialization
	void Start ()
    {
        moneyScript = GameObject.Find("MoneyManager").GetComponent<PlayerMoney>();

        //Set input field to regular
        inputField = regularField;
        reward = regularReward;

        //Bonus challenge script
        bonusChallengeScript = GetComponent<BonusChallenge>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (float.TryParse(inputField.text, out enteredAnswer))
        {
            //Correct Answer
            if (enteredAnswer == correctAnswer)
            {
                //Add money
                moneyScript.addMoney(reward);

                //Display money
                balanceText.text = moneyScript.getBalance().ToString();

                //Feedback
                inputField.text = "";

                if (!bonusMode)
                {
                    //Open chest
                    chestScript.AdvanceChest();

                    //Generate new question
                    questionScript.generateNewQuestion();
                }
                else
                {
                    //Show bonus challenge win page
                    bonusChallengeScript.enableWinPage();
                }
            }
        }
		
	}

    //Set answer
    public void setCorrectAnswer(float answer)
    {
        correctAnswer = answer;
    }

    //Get Answer
    public float getCorrectAnswer()
    {
        return correctAnswer;
    }

    //Switch between modes
    public void bonusModeEnabled(bool isEnabled)
    {

        if(isEnabled)         //Bonus
        {
            inputField = bonusField;
            reward = bonusReward;
            bonusMode = true;
        }
        else                 //Regular
        {
            inputField = regularField;
            reward = regularReward;
            bonusMode = false;
        }
    }
}
