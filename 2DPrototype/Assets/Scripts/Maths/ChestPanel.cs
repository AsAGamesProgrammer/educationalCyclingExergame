using System.Collections;
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

    // Use this for initialization
    void Start ()
    {
        moneyScript = GameObject.Find("MoneyManager").GetComponent<PlayerMoney>();
        
        //Progress script
        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();

        //Initial challenge
        currentParts = mapParts;
        currentImage = mapImage;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUp(int level)
    {
        currentSpriteNumber = -1;
        currentImage.gameObject.SetActive(false);

        switch (level)
        {
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
        }

        //Add money

        moneyScript.addMoney(progressScript.GetReward());
    }


}
