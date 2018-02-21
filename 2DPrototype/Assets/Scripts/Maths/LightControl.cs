using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour {

    public Text taskText;
    private float currentVisibility = 0.0f;
    public float lightSpeedInc = 0.05f;
    public float lightSpeedDec = 0.01f;

    public float lastValue = 0.0f;
    public float currentValue = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Color textColour = taskText.color;

        float temp = Input.GetAxis("Vertical");

        if (temp < 0.1 && currentVisibility >= 0f)
        {
            currentVisibility -= lightSpeedDec;
        }
        else
        {
            currentVisibility = Input.GetAxis("Vertical") * 2;
        }

        textColour.a = currentVisibility;
        taskText.color = textColour;
	}
}
