using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarProgress : MonoBehaviour {

    public int level = 0;
    public int stage = 0;

    public bool readyToLevel = false;

	// Use this for initialization
	void Start ()
    {

        if (SceneManager.GetActiveScene().name == "mathsQuestions")
        {
            //background change
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ChangeBackground>().ChangeLevel(level);
        }

    }
	
	public void NextStage(int officialStage)
    {
        stage = officialStage;

        if (stage >= 3)
            stage = 0;
    }

    public void NextLevel()
    {
        level++;

        //Banner text
        GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<Text>().text = "Level " + (level + 1).ToString();

        //background change
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ChangeBackground>().ChangeLevel(level);

    }

    public void ChangeBanner()
    {
        //Change banner
        GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<Text>().text = "Level " + (level + 1).ToString();
    }

    //--------------REWARDS----------------
    //Get usual reward for opening the chest
    public int GetReward()
    {
        return CalculateReward(10);
    }

    //Get bigger reward for solving bonus challenge
    public int GetBonusReward()
    {
        return CalculateReward(50);
    }

    //Reward calculation algorithm
    int CalculateReward(int initialReward)
    {
        int reward = initialReward;

        for (int i = 0; i < level; i++)
        {
            reward *= 10;
        }

        return reward;
    }
}
