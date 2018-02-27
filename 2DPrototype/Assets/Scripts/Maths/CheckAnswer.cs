using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour {

    public Question questionScript;
    public float correctAnswer = 56;
    float enteredAnswer;
    public Text feedback;
    public InputField inputField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (float.TryParse(inputField.text, out enteredAnswer))
        {
            if (enteredAnswer == correctAnswer)
            {
                feedback.text = "Yes";
                questionScript.generateNewQuestion();
            }
        }
		
	}

    public void setCorrectAnswer(float answer)
    {
        correctAnswer = answer;
    }
}
