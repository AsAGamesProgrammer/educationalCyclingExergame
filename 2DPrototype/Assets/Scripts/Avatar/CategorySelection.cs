﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// TARGET: Empty game object - Manager, 
///         which has AvatarPartCollection, CategorySelection and RotateSelection scripts attached
/// PURPOSE: - React on button clicks (avatar categories)
/// </summary>

public class CategorySelection : MonoBehaviour {

    private AvatarPartsCollection avatarCollection;
    public List<GameObject> selectableItems = new List<GameObject>();

    //Currents
    public spriteType currentCategory = spriteType.none;
    public spriteColour currentSkinColour = spriteColour.skinBrown;

    //Borders
    public GameObject rightBorder;
    public GameObject leftBorder;

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
        switch(name)
        {
            case "FaceShape":
                if (currentCategory != spriteType.faceShape)
                {
                    currentCategory = spriteType.faceShape;
                    CreateSelectionItems();
                }
                break;

            case "SkinColour":
                if (currentCategory != spriteType.skin)
                {
                    currentCategory = spriteType.skin;
                    CreateSelectionItems();
                }
                break;
        }
    }

    public void CreateSelectionItems()
    {
        //Clear list
        foreach (var item in selectableItems)
        {
            Destroy(item);
        }
        selectableItems = new List<GameObject>();

        List<SpriteInstance> currentCollection = new List<SpriteInstance>();

        switch(currentCategory)
        {
            case spriteType.faceShape:
                currentCollection = avatarCollection.faceShapes;
                break;

            case spriteType.skin:
                currentCollection = avatarCollection.skinColours;
                break;

            default:
                return;
        }

        foreach(var item in currentCollection)
        {
            if(ItemIsValid(item))
            {
                //-------CREATES NEW ITEM--------
                GameObject newItem = new GameObject();

                //Sprite Renderer
                newItem.AddComponent<SpriteRenderer>();
                newItem.GetComponent<SpriteRenderer>().sprite = item.spriteObject;

                //Script
                newItem.AddComponent<AvatarDescription>();

                //ID
                newItem.GetComponent<AvatarDescription>().spriteId = item.spriteId;

                //Dye
                if(item.type==spriteType.skin)
                {
                    newItem.GetComponent<AvatarDescription>().SkinDye = item.colour;
                }

                //Hair
                if (item.type == spriteType.hairDown || item.type == spriteType.hairUp)
                {
                    newItem.GetComponent<AvatarDescription>().HairDye = item.colour;
                }

                //Instantiate
                selectableItems.Add(newItem);
            }
        }

        //Reposition
        RepositionSelectionItems();

        //Upload Items to the selection script
        GetComponent<RotateSelection>().SetUpArray(selectableItems);
    }

    bool ItemIsValid(SpriteInstance item)
    {
        //Check skin colour
        if(item.type==spriteType.faceShape)
        {
            if (item.colour == currentSkinColour)
                return true;
        }
        else
        {
            return true;
        }

        return false;
    }

    public void RepositionSelectionItems()
    {
        float width = Vector2.Distance(rightBorder.transform.position, leftBorder.transform.position);
        float modifier = width / selectableItems.Count;
        float offset = modifier/2;

        foreach(var item in selectableItems)
        {
            item.transform.position = new Vector2(leftBorder.transform.position.x + offset, leftBorder.transform.position.y);
            offset += modifier;
        }
    }
}
