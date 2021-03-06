﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour {

    //Images
    public Image lighthouse;
    public Image shipImage;
    public Image mapImage;

    //Arrays
    public Sprite[] mapParts;
    public Sprite[] lighthouseParts;
    public Sprite[] shipParts;

    private Sprite[] currentParts;
    private Image currentImage;

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

    //Progress
    AvatarProgress progressScript;

    //Audio
    MathsAudio audioManager;

    // Use this for initialization
    void Start ()
    {
        moneyScript = GameObject.Find("MoneyManager").GetComponent<PlayerMoney>();
        
        //Progress script
        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();

        //Audio
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<MathsAudio>();

        //Initial collection
        currentParts = mapParts;
        currentImage = mapImage;

        //Check against progress script
        LevelUp(progressScript.level);

        LoadProgress();
    }

    public void LevelUp(int level)
    {
        currentSpriteNumber = -1;
        currentImage.gameObject.SetActive(false);

        switch (level)
        {
            case 0:
                currentParts = mapParts;
                currentImage = mapImage;
                break;

            case 1:
                currentParts = lighthouseParts;
                currentImage = lighthouse;
                break;

            case 2:
                currentParts = shipParts;
                currentImage = shipImage;
                break;

            default:
                currentParts = shipParts;
                currentImage = shipImage;
                break;
        }

        currentImage.gameObject.SetActive(true);
    }

    void LoadProgress()
    {
        currentSpriteNumber = progressScript.stage * 3;
        currentSpriteNumber--;

        if (currentSpriteNumber < 0 && !progressScript.readyToLevel)
            return;

        //Enable bonus
        if (progressScript.readyToLevel)
        {
            //Test is available
            bonusExists = true;                //change flag
            lvlUpBtn.SetActive(true);          //enable btn

            //Lvl up available sound
            audioManager.PlayLvlUpAvailable();

            //Load last img
            currentSpriteNumber = currentParts.Length - 1;

            Debug.Log("Ready to level loaded");
        }

        currentImage.sprite = currentParts[currentSpriteNumber];
    }

    public void addChest()
    {
        //Open up next piece of the lighthouse
        if (currentSpriteNumber < currentParts.Length - 1)
        {
            Debug.Log("Applying picture " + currentSpriteNumber);
            currentSpriteNumber++;
            currentImage.sprite = currentParts[currentSpriteNumber];
        }

        //Enable bonus
        if (currentSpriteNumber >= currentParts.Length - 1)
        {
            //Test is available
            bonusExists = true;                //change flag
            lvlUpBtn.SetActive(true);          //enable btn

            //Lvl up available sound
            audioManager.PlayLvlUpAvailable();

            progressScript.readyToLevel = true;
        }

        //Add money
        moneyScript.addMoney(progressScript.GetReward());
    }


}
