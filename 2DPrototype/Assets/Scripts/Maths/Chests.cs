using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour {

    //Chests in a middle of a screen
    public GameObject[] chests;
    public Sprite[] chestSprites;

    //Variables
    int currentChest = 0; //id of the current chest
    int currentPhase = 0; //Phase of inidividual chest
    int currentStage = 0; //Highest sprite index
    int initialPhase = 0; //What sprite the chest sequence starts at
    public int officialStage = 0; //Round number (wooden = 0, blue = 1, purple = 2)

    //Chest panel
    public ChestPanel chestPanelScript;

    //Particles
    public ParticleManager particleScript;

    //Avatar progress script
    public AvatarProgress progressScript;

    public void Start()
    {
        //Find script
        progressScript = GameObject.FindGameObjectWithTag("AvatarTransfer").GetComponent<AvatarProgress>();
    }

    //Chests in a middle of a screen
    public void AdvanceChest()
    {
        //Open chest 
        openCurrentChest();

        //Reached the end of the chest
        if (currentPhase > currentStage)
        {
            //Reset phase of the chest 
            currentPhase = initialPhase;

            //Finished a chest
            sendChestToBonus();

            //Advance to next chest
            if (currentChest < chests.Length-1)
            {
                currentChest++;
            }
            else //Go to the first chest
            {
                currentChest = 0;

                //Insrease stage TEST
                currentStage += 3 + officialStage;
                officialStage++;
                progressScript.NextStage(officialStage);
                initialPhase = currentStage - officialStage;
                currentPhase = initialPhase;

                //If all the stages of the level were complete
                if (initialPhase >= chestSprites.Length) 
                {
                    //Reset variables
                    ResetChestSequence();
                }

                //Beginning
                if (currentChest == 0)
                {
                    //Replace sprites
                    foreach (var chest in chests)
                    {
                        chest.GetComponent<SpriteRenderer>().sprite = chestSprites[initialPhase];
                    }

                    //Special case: purple 
                    if (officialStage == 2)
                    {
                        chests[0].SetActive(false);
                        chests[1].SetActive(false);
                        currentChest = 2;
                    }

                }

            }
        }
    }

    //Public function
    public void StartRound()
    {
        ResetChestSequence();

        //Replace sprites
        foreach (var chest in chests)
        {
            chest.GetComponent<SpriteRenderer>().sprite = chestSprites[initialPhase];
        }
    }

    //Makes all the key variables to be equal to 0
    void ResetChestSequence()
    {
        currentChest = 0;   
        currentPhase = 0;
        currentStage = 0;
        initialPhase = 0;   //What sprite the chest sequence starts at
        officialStage = 0;  //Round number (wooden = 0, blue = 1, purple = 2)

        //Reactivate chests
        chests[0].SetActive(true);
        chests[1].SetActive(true);
    }

    //Open current: swap sprites on the current chest
    private void openCurrentChest()
    {
        //Increase phase
        currentPhase++;

        //Swap sprites
        chests[currentChest].GetComponent<SpriteRenderer>().sprite = chestSprites[currentPhase];
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
