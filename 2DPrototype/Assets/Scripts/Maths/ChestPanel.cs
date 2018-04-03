using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour {

    public Image lighthouse;
    public Sprite[] lighthouseParts;
    //public Sprite openChest;
    //public Sprite transparentSprite;
    int currentSpriteNumber = -1;

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

        if (currentSpriteNumber < lighthouseParts.Length - 1)
        {
            Debug.Log("Applying picture " + currentSpriteNumber);
            currentSpriteNumber++;
            lighthouse.sprite = lighthouseParts[currentSpriteNumber];
        }
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
