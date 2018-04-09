using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {

    public GameObject[] backgrounds = new GameObject[3];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeLevel(int level)
    {
        foreach (var background in backgrounds)
            background.SetActive(false);

        backgrounds[level].SetActive(true);

    }
}
