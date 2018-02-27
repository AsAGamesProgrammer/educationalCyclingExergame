using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour {

    public GameObject[] chests;
    public Sprite[] chestSprites;
    int currentChest = 0;
    int currentPhase = 0;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

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
            if (currentChest < chests.Length-1)
            {
                currentChest++;
                chests[currentChest].GetComponent<SpriteRenderer>().sprite = chestSprites[currentPhase];
            }
        }
    }
}
