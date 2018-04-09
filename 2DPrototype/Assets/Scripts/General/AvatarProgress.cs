using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarProgress : MonoBehaviour {

    public int level = 0;
    public int stage = 0;

	// Use this for initialization
	void Start ()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //background change
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ChangeBackground>().ChangeLevel(level);
        }

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

    public int GetReward()
    {
        switch(level)
        {
            case 0:
                return 10;

            case 1:
                return 100;

            case 2:
                return 500;

            default:
                return 10;
        }

    }
}
