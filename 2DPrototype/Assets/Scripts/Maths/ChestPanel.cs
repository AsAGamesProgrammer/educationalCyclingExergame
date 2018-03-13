using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour {

    public Image[] chests;
    public Sprite openChest;
    int availableChestNumber = 0;

    //Script for bonus challenge
    public BonusChallenge bonusChallenge;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addChest()
    {
        //Indicate that chests exist and bonus challenge is available
        bonusChallenge.bonusExists = true;

        //Add a new chest if there is space
        if (availableChestNumber < chests.Length)
        {
            chests[availableChestNumber].sprite = openChest;
            availableChestNumber++;
        }
    }
}
