using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour {

    public Text taskText;
    public Text taskShadowText;
    private float currentVisibility = 0.0f;
    public float lightSpeedInc = 0.05f;
    public float lightSpeedDec = 0.01f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Main question
        Color textColour = taskText.color;
        Color shadowColor = taskShadowText.color;

        float temp = Input.GetAxis("Vertical");

        if (temp < 0.05 && currentVisibility >= 0f)
        {
            currentVisibility -= lightSpeedDec;
        }
        else if (temp >0.05 && currentVisibility<=1f)
        {
            currentVisibility += lightSpeedInc;
        }

        //Main 
        textColour.a = currentVisibility;
        taskText.color = textColour;

        //Shadow
        shadowColor.a = currentVisibility;
        taskShadowText.color = shadowColor;
	}
}
