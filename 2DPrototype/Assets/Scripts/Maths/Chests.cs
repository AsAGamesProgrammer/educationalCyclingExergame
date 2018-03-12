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

    //Chests in a middle of a screen
    public void AdvanceChest()
    {
        //Open up
        if (currentPhase < chestSprites.Length-1)
        {
            openCurrentChest();
        }
        else
        {
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
        if(currentChest>0)
        {
            chests[currentChest-1].GetComponent<SpriteRenderer>().sprite = chestSprites[0];
        }
        else
        {
            chests[chests.Length-1].GetComponent<SpriteRenderer>().sprite = chestSprites[0];
        }

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
