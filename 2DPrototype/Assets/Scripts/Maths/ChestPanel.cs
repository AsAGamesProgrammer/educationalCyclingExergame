using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour {

    //Images
    public Image lighthouse;
    public Sprite[] lighthouseParts;

    //Current picture indicator
    int currentSpriteNumber = -1;

    //Script for bonus challenge
    public BonusChallenge bonusChallenge;

    //Button for lvl up
    public GameObject lvlUpBtn;

    //Indicates if bonus challenge is available
    public bool bonusExists = false;

    //Money script
    PlayerMoney moneyScript;
    int reward = 10;

    // Use this for initialization
    void Start ()
    {
        moneyScript = GameObject.Find("MoneyManager").GetComponent<PlayerMoney>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addChest()
    {
        //Open up next piece of the lighthouse
        if (currentSpriteNumber < lighthouseParts.Length - 1)
        {
            Debug.Log("Applying picture " + currentSpriteNumber);
            currentSpriteNumber++;
            lighthouse.sprite = lighthouseParts[currentSpriteNumber];
        }
        
        //Enable bonus
        if(currentSpriteNumber >= lighthouseParts.Length - 1)
        {
            //Test is available
            bonusExists = true;                //change flag
            lvlUpBtn.SetActive(true);          //enable btn
        }

        //Add money
        moneyScript.addMoney(reward);
    }

    //Removes the chest from the bonus panel after it was claimed
    //public void removeChest()
    //{
    //    availableChestNumber--;
    //    chests[availableChestNumber].sprite = transparentSprite;

    //    if (availableChestNumber <= 0)
    //    {
    //        bonusChallenge.bonusExists = false;
    //    }
    //}
}
