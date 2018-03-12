using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour {

    //Chests in a middle of a screen
    public GameObject[] chests;
    public Sprite[] chestSprites;
    int currentChest = 0;
    int currentPhase = 0;

    //Chest panel
    public ChestPanel chestPanelScript;

    //Chests in a middle of a screen
    public void AdvanceChest()
    {
        //Open up
        if (currentPhase < chestSprites.Length-1)
        {
            currentPhase++;
            chests[currentChest].GetComponent<SpriteRenderer>().sprite = chestSprites[currentPhase];
        }
        else
        {
            currentPhase = 1;

            //test
            chestPanelScript.addChest();

            if (currentChest < chests.Length-1)
            {
                currentChest++;
                chests[currentChest].GetComponent<SpriteRenderer>().sprite = chestSprites[currentPhase];
            }
        }
    }
}
