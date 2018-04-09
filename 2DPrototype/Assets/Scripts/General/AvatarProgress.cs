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
        //background change
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ChangeBackground>().ChangeLevel(level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextLevel()
    {
        level++;

        //Banner text
        GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<Text>().text = "Level " + (level + 1).ToString();

        //background change
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ChangeBackground>().ChangeLevel(level);

    }
}
