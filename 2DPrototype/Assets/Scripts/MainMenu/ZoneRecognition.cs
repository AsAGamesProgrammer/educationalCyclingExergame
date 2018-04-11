using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TARGET: Attached to the collider on the bike
/// </summary>

public class ZoneRecognition : MonoBehaviour {

    public RotationScriptMenu rotationScript;

	// Use this for initialization
	void Start ()
    {
		
	}
	

    //On collision with the zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MenuZone")
        {
            rotationScript.ZoneChanged(other.gameObject.GetComponent<ZoneInformation>().thisZone);
        }
    }
}
