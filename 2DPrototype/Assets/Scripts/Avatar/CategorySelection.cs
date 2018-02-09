﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategorySelection : MonoBehaviour {

    public spriteColour currentSkinColour = spriteColour.skinBrown;
    private AvatarPartsCollection avatarCollection;

    public List<GameObject> selectableItems = new List<GameObject>();
    //public GameObject prefab;
    public GameObject testCube;

	// Use this for initialization
	void Start ()
    {
        avatarCollection = GetComponent<AvatarPartsCollection>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBtnClick(string name)
    {
        Debug.Log(name + "Something Clicked");
        CreateSelectionItems();
    }

    public void CreateSelectionItems()
    {
        foreach(var item in avatarCollection.faceShapes)
        {
            //Temp!!!
            if(item.colour == currentSkinColour)
            {
                GameObject newItem = new GameObject();

                //Sprite Renderer
                newItem.AddComponent<SpriteRenderer>();
                newItem.GetComponent<SpriteRenderer>().sprite = item.spriteObject;

                //Script
                newItem.AddComponent<AvatarDescription>();

                //Instantiate
                selectableItems.Add(newItem);
            }
        }

        //Reposition
    }

    public void RepositionSelectionItems()
    {
        foreach(var item in selectableItems)
        {
            Instantiate(item, testCube.transform.position, testCube.transform.rotation);
        }
    }
}
