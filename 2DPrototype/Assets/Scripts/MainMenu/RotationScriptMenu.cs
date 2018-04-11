using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationScriptMenu : MonoBehaviour {

    //Zone
    public MenuZones currentZone;

    //Sphere which rotates the bike
    public GameObject rotationSphere;

    //Speed f rotation
    public float speed = 5f;

    //GUI
    public Text selectedText;

	// Use this for initialization
	void Start ()
    {
        //Set middle text to what is currently selected
        selectedText.text = currentZone.ToString().ToUpper();
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
    }
}

public enum MenuZones
{
    Start,
    Options,
    Credits,
    Exit
}
