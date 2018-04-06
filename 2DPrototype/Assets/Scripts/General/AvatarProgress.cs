using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarProgress : MonoBehaviour {

    public int level = 0;
    public int stage = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextLevel()
    {
        level++;

        GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<Text>().text = "Level " + level.ToString();

        //TODO
        //Reset chest sequence
    }
}
