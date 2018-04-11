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

    //Audio
    MathsAudio audioManager;

    //Modes
    bool bonusMode = false;

    //Bonus challenge script
    BonusChallenge bonusChallengeScript;

    //Avatar progress
    AvatarProgress progressScript;

	// Use this for initialization
	void Start ()
    {
        //Set input field to regular
        inputField = regularField;
        reward = regularReward;

        //Bonus challenge script
        bonusChallengeScript = GetComponent<BonusChallenge>();

        //Audio
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<MathsAudio>();

        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (float.TryParse(inputField.text, out enteredAnswer))
        {
            if (enteredAnswer < 10)
                return;

            //Correct Answer
            if (enteredAnswer == correctAnswer)
            {
                //Feedback
                inputField.text = "";
                inputField.placeholder.GetComponent<Text>().text = "Enter answer";

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
                    bonusChallengeScript.enableWinPage(progressScript.level);

                    //Stop timer
                    bonusChallengeScript.countdownEnabled = false;
                }
            }
            else
            {
                HandleIncorrectAnswer();

            }
        }
		
	}

    void HandleIncorrectAnswer()
    {
        //Audio
        audioManager.PlayIncorrectAnswer();

        inputField.text = "";
        int randomPhrase = Random.Range(1, 5);
        switch (randomPhrase)
        {
            case 1:
                inputField.placeholder.GetComponent<Text>().text = "NOT EXACTLY...";
                break;

            case 2:
                inputField.placeholder.GetComponent<Text>().text = "TRY AGAIN";
                break;

            case 3:
                inputField.placeholder.GetComponent<Text>().text = "MM, NOT REALLY";
                break;

            case 4:
                inputField.placeholder.GetComponent<Text>().text = "ARE YOU SURE?..";
                break;

            default:
                inputField.placeholder.GetComponent<Text>().text = "NOT EXACTLY...";
                break;
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
