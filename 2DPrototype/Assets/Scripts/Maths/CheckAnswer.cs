using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour {

    public string correctAnswer = "56p";
    public Text feedback;
    public InputField inputField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(inputField.text == correctAnswer)
        {
            feedback.text = "Yes";
        }

		
	}
}
