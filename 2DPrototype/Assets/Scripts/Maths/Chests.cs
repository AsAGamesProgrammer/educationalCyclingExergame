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

    //Particles
    public ParticleManager particleScript;

    //Stages
    int currentStage = 0;


    //Chests in a middle of a screen
    public void AdvanceChest()
    {
        Debug.Log("Chest " + currentChest + " at phase " + currentPhase + ", stage " + currentStage);

        //Open chest 
        openCurrentChest();

        //Reached the end of the chest
        if (currentPhase > currentStage)
        {
            Debug.Log("reached the end " + currentPhase);

            currentPhase = 0;

            //Finished a chest
            sendChestToBonus();

            //Advance to next chest
            if (currentChest < chests.Length-1)
            {
                currentChest++;
                //chests[currentChest].GetComponent<SpriteRenderer>().sprite = chestSprites[currentPhase];
            }
            else
            {
                currentChest = 0;

                //Insrease stage 
                currentStage++;
            }
        }
    }

    //Open current: swap sprites on the current chest
    private void openCurrentChest()
    {
        //Increase phase
        currentPhase++;
        //Swap sprite
        chests[currentChest].GetComponent<SpriteRenderer>().sprite = chestSprites[currentPhase];

        //Close previous chest
        //if(currentChest>0)
        //{
        //    chests[currentChest-1].GetComponent<SpriteRenderer>().sprite = chestSprites[0];
        //}
        //else //First chest
        //{
        //    chests[chests.Length-1].GetComponent<SpriteRenderer>().sprite = chestSprites[0];
        //}

    }

    //Finsihed chest
    private void sendChestToBonus()
    {
        //Add chest to the right panel
        chestPanelScript.addChest();
        //Play particles
        particleScript.playOnceAt(chests[currentChest].transform.position);
    }
}
