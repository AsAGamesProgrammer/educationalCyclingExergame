﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Horizontal " + Input.GetAxis("Horizontal") + "Vertical " + Input.GetAxis("Vertical"));



    }
}
