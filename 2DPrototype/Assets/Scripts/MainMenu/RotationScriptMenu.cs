using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RotationScriptMenu : MonoBehaviour {

    //Zone
    public MenuZones currentZone;

    //Sphere which rotates the bike
    public GameObject rotationSphere;

    //Speed f rotation
    public float speed = 5f;

    //GUI
    public Text selectedText;
    public GameObject innerCircle;

    //Colours
    public Color startColour;
    public Color optionColour;
    public Color creditsColour;
    public Color exitColour;

    // Use this for initialization
    void Start ()
    {
        //Set middle text to what is currently selected
        selectedText.text = currentZone.ToString().ToUpper();

        ChangeInnerCircleColour();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vertical input detected
        if (Input.GetAxis("Vertical") > 0.05f)
        {
            rotationSphere.transform.Rotate(0, 0, -Input.GetAxis("Vertical") * Time.deltaTime * speed);
        }
    }

    //Called externally
    public void ZoneChanged(MenuZones zone_)
    {
        currentZone = zone_;
        //Set middle text to what is currently selected
        selectedText.text = currentZone.ToString().ToUpper();

        ChangeInnerCircleColour();
    }


    //Change the colour of the inner circle
    void ChangeInnerCircleColour()
    {
        Debug.Log(currentZone);
        switch (currentZone)
        {
            case MenuZones.Start:
                innerCircle.GetComponent<SpriteRenderer>().color = startColour;
                break;

            case MenuZones.Options:
                innerCircle.GetComponent<SpriteRenderer>().color = optionColour;
                break;

            case MenuZones.Credits:
                innerCircle.GetComponent<SpriteRenderer>().color = creditsColour;
                break;

            case MenuZones.Exit:
                innerCircle.GetComponent<SpriteRenderer>().color = exitColour;
                break;
        }
    }

    //------------BUTTON CLICK-------------

    public void OnButtonClick()
    {
        switch (currentZone)
        {
            case MenuZones.Start:
                SceneManager.LoadScene("avatarCreation");
                break;

            case MenuZones.Options:
                SceneManager.LoadScene("Options");
                break;

            case MenuZones.Credits:
                SceneManager.LoadScene("Credits");
                break;

            case MenuZones.Exit:
                Application.Quit();
                break;
        }
    }
}



public enum MenuZones
{
    Start,
    Options,
    Credits,
    Exit
}
