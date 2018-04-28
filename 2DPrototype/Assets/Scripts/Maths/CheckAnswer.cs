using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour {

    //Reference to a question script
    public Question questionScript;

    //Correct and enntered answers
    float correctAnswer = 56;
    float enteredAnswer;

    //Reference to the bonus script
    public Chests chestScript;

    //Input fields
    public InputField regularField;
    public InputField bonusField;
    InputField inputField;

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

        //Generate a random number between 1 and 4
        int randomPhrase = Random.Range(1, 5);

        //Choose a feedback phrase based on the random number
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
            bonusMode = true;
        }
        else                 //Regular
        {
            inputField = regularField;
            bonusMode = false;
        }
    }
}
