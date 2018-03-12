using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour {

    public Image[] chests;
    public Sprite openChest;
    int availableChestNumber = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addChest()
    {
        if (availableChestNumber < chests.Length)
        {
            chests[availableChestNumber].sprite = openChest;
            availableChestNumber++;
        }
    }
}
