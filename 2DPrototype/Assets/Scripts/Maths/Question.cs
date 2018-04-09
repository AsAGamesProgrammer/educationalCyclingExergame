using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {


    public Text questionText;       //Non-bonus
    public Text questionShadowText;       //Non-bonus
    public Text bonusQuestionText;  //Bonus

    public CheckAnswer answerScript;

    //Avatar progress script
    public AvatarProgress progressScript;

	// Use this for initialization
	void Start ()
    {
        //Find script
        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();

        generateNewQuestion();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void generateSimpleMix()
    {
        int flag = Random.Range(0, 2);  //Generate random value true/false

        if (flag == 0)
            generateSimpleAddition();   //Generate addition if flag is 0
        else
            generateSimpleSubstraction(); //Generate substraction if flag is 1
    }

    //Generate question
    // Level 0 - addition
    // Level 1 - substraction
    // Level 2 - mix
    public void generateNewQuestion()
    {
        //Generate question based on level
        switch(progressScript.level)
        {
            case 0:                         
                generateSimpleAddition();
                break;

            case 1:
                generateSimpleSubstraction();   
                break;

            case 2:
                generateSimpleMix();
                break;

            default:
                generateSimpleMix();
                break;

        }
    }

    //-----------------------QUESTION TYPES-------------------------

    //REGULAR-------------------------------------------------------
    //TYPE A
    //Example: 10p + 34p
    void generateSimpleAddition()
    {
        int numberA = Random.Range(1, 90);              //get random int between 1-90

        int difference = 100 - numberA;                 //get the maximum value of the second int
        int numberB = Random.Range(1, difference);      //randomly generate second int

        questionText.text = numberA.ToString() + "p + " + numberB + "p";

        //Test
        questionShadowText.text = questionText.text;

        answerScript.setCorrectAnswer(numberA + numberB);  //Set answer

        Debug.Log(numberA + numberB);
    }

    //TYPE B
    //Example: 20p - 4p
    void generateSimpleSubstraction()
    {
        int numberA = Random.Range(1, 90);              //get random int between 1-90

        int difference = 100 - numberA;                 //get the maximum value of the second int
        int numberB = Random.Range(1, difference);      //randomly generate second int

        if (numberA > numberB)                          //Substract smaller number from the greater one
        {
            questionText.text = numberA.ToString() + "p - " + numberB + "p";
            answerScript.setCorrectAnswer(numberA - numberB);  //Set answer
            Debug.Log(numberA - numberB);
        }
        else
        {
            questionText.text = numberB.ToString() + "p - " + numberA + "p";
            answerScript.setCorrectAnswer(numberB - numberA);  //Set answer
            Debug.Log(numberB - numberA);
        }

 
    }

    //BONUS------------------------------------------------------------
    //TYPE A
    //Example: Find the total of 70p and 30p
    public void generateBonusAddition()
    {
        int numberA = Random.Range(1, 90);              //get random int between 1-90

        int difference = 100 - numberA;                 //get the maximum value of the second int
        int numberB = Random.Range(1, difference);      //randomly generate ssecond int

        bonusQuestionText.text = "Find the total of " + numberA + "p and " + numberB + "p";
        answerScript.setCorrectAnswer(numberA + numberB);  //Set answer
    }

}
