using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour {

    public Question questionScript;
    float correctAnswer = 56;
    float enteredAnswer;
    public InputField inputField;
    public Text balanceText;
    public Chests chestScript;

    //Money
    int reward = 10;
    

    PlayerMoney moneyScript;

	// Use this for initialization
	void Start ()
    {
        moneyScript = GameObject.Find("MoneyManager").GetComponent<PlayerMoney>();
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

                //Open chest
                chestScript.AdvanceChest();

                //Generate new question
                questionScript.generateNewQuestion();
            }
        }
		
	}

    public void setCorrectAnswer(float answer)
    {
        correctAnswer = answer;
    }
}
