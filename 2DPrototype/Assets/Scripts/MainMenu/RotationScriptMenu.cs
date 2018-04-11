using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScriptMenu : MonoBehaviour {

    public MenuZones currentZone;

    public GameObject rotationSphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vertical input detected
        if (Input.GetAxis("Vertical") > 0.05f)
        {
            rotationSphere.transform.Rotate(0, 0 *  Time.deltaTime, -Input.GetAxis("Vertical"));
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
