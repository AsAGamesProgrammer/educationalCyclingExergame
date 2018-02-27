using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {

    public Text questionText;
    public CheckAnswer answerScript;

	// Use this for initialization
	void Start ()
    {
        generateQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void generateQuestion()
    {
        //TYPE A
        int numberA = Random.Range(1, 90);

        int difference = 100 - numberA;
        int numberB = Random.Range(1, difference);

        questionText.text = numberA.ToString() + "p + " + numberB + "p";
        answerScript.setCorrectAnswer(numberA + numberB);

        //TYPE A
        //Number A + Number B
        //get random int between 1-90
        //get random int between 100-prevInt
        //Randm places
        //Add

        //TYPE B
        //Decimal A + Pences

    }

    public void generateNewQuestion()
    {
        generateQuestion();
    }

}
