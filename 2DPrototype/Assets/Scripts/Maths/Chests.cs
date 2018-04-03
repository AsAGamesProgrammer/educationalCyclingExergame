using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour {

    //Chests in a middle of a screen
    public GameObject[] chests;
    public Sprite[] chestSprites;
    int currentChest = 0;
    int currentPhase = 0;
    int initialPhase = 0;

    //Chest panel
    public ChestPanel chestPanelScript;

    //Particles
    public ParticleManager particleScript;

    //Stages
    int currentStage = 0;


    //Chests in a middle of a screen
    public void AdvanceChest()
    {

        /*
         Set all chests to first sprite
         Open all the phases

        if(there is another chest)
         Advance to next chest
         else
         Fireworks
         replace all sprites
         
         */
        //Open chest 
        openCurrentChest();

        //Reached the end of the chest
        if (currentPhase > currentStage)
        {
            Debug.Log("reached the end " + currentPhase);

            //Test
            currentPhase = initialPhase;

            //Finished a chest
            sendChestToBonus();

            //Advance to next chest
            if (currentChest < chests.Length-1)
            {
                currentChest++;
                //chests[currentChest].GetComponent<SpriteRenderer>().sprite = chestSprites[currentPhase];
            }
            else //Go to the first chest
            {
                currentChest = 0;

                //Insrease stage TEST
                currentStage+=3;
                initialPhase = currentStage - 1;

                //Beginning
                if (currentChest == 0)
                {
                    //Replace sprites
                    Debug.Log("Opening all chests");
                    foreach (var chest in chests)
                    {
                        chest.GetComponent<SpriteRenderer>().sprite = chestSprites[initialPhase];
                    }
                }

            }
        }
    }

    //Open current: swap sprites on the current chest
    private void openCurrentChest()
    {
        //Increase phase
        currentPhase++;
        //Swap sprite
        Debug.Log("Opening chest " + currentChest + " at phase " + currentPhase + ", stage " + currentStage);
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
