﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TARGET: Empty game object - Manager, 
///         which has AvatarPartCollection, CategorySelection and RotateSelection scripts attached
/// PURPOSE: - React to arrow keys and pedalling
/// </summary>

public class RotateSelection : MonoBehaviour {

    //Array of avatar elements which can be selected
    public AvatarDescription[] avatarElements;

    //Main avatar sprite, which is changed 
    public GameObject mainSprite;

    public GameObject partS;
    public GameObject bike;
    public GameObject spriteOnBike;
    private int currentSelectedSprite = 0;

    public float progressToUnlock = 100.0f;
    private bool verticalSelectionActive = false;
    private float currentVerticalProgress = 0.03f;
    public float extraSpeedModifier = 0.15f;

    private bool bikeSpriteSet = false;
    private Vector2 initialBikePos;

    //START
    // Use this for initialization
    void Start ()
    {
        initialBikePos = bike.transform.position;
	}
	
    //UPDATE
	// Update is called once per frame
	void Update ()
    {
        //Check for input and change sprite selection
        if (!verticalSelectionActive)
        {
            if (HorizontalInputReceived())
                ChangeSelection();
        }

        //Vertical input detected
        if (Input.GetAxis("Vertical") > 0.05f && mainSprite.GetComponent<SpriteRenderer>().sprite != avatarElements[currentSelectedSprite].getSprite())
        {
            verticalSelectionActive = true;

            VerticalSelection();
        }
    }

    void VerticalSelection()
    {
        //Bike on the move towards avatar
        if (currentVerticalProgress < progressToUnlock)
        {
            //Debug
            Debug.Log(currentVerticalProgress);

            //Add current spinning value
            currentVerticalProgress += Input.GetAxis("Vertical");

            //Move bike
            bike.transform.position += Vector3.right * Input.GetAxis("Vertical") * extraSpeedModifier;
        }
        else //Bike reached avatar
        {
            //SPECIAL CASES
            //Skin colour 
            if (avatarElements[currentSelectedSprite].SkinDye != spriteColour.none)
            {
                this.GetComponent<CategorySelection>().currentSkinColour = avatarElements[currentSelectedSprite].SkinDye;
                ChangeFaceToMatchSkin();
                ChangeBodyToMatchSkin();
                //Change face
            }
            else
            if (avatarElements[currentSelectedSprite].HairDye != spriteColour.none)
            {
                this.GetComponent<CategorySelection>().currentSkinColour = avatarElements[currentSelectedSprite].HairDye;
            }

            //Change sprite picture
            mainSprite.GetComponent<SpriteRenderer>().sprite = avatarElements[currentSelectedSprite].getSprite();

            //Change ID
            mainSprite.GetComponent<CurrentAvatarDescription>().spriteId = avatarElements[currentSelectedSprite].spriteId;

            currentVerticalProgress = 0.1f;
            verticalSelectionActive = false;

            //Return bike to the beginning
            bike.transform.position = initialBikePos;

            //Set selection to none
            spriteOnBike.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    //Check for arrow key input
    //Change currently selected sprite accordingly
    bool HorizontalInputReceived()
    {
        bool changeSpriteSelection = false;

        //ARROW RIGHT
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSelectedSprite + 1 < avatarElements.Length)
                currentSelectedSprite++;
            else
                currentSelectedSprite = 0;

            changeSpriteSelection = true;
        }

        //ARROW LEFT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelectedSprite > 0)
                currentSelectedSprite--;
            else
                currentSelectedSprite = avatarElements.Length - 1;

            changeSpriteSelection = true;
        }

        return changeSpriteSelection;
    }

    //Respond to arrow key input to indicate which picture is selected
    void ChangeSelection()
    {
        //Move particles
        partS.transform.position = new Vector2(avatarElements[currentSelectedSprite].getPosition().x, -4.5f);

        //Set on bike sprite to a current selection only if it is npt applied yet
        if (mainSprite.GetComponent<SpriteRenderer>().sprite != avatarElements[currentSelectedSprite].getSprite())
        {
            spriteOnBike.GetComponent<SpriteRenderer>().sprite = avatarElements[currentSelectedSprite].getSprite();
        }
        else
        {
            spriteOnBike.GetComponent<SpriteRenderer>().sprite = null;
        }
        
    }

    void ChangeFaceToMatchSkin()
    {
        //Query a list by number
        //Look for the skin colour
        GameObject faceSprite = GameObject.FindGameObjectWithTag("MainAvatar").transform.Find(spriteType.faceShape.ToString()).gameObject;
        int currentFaceId = faceSprite.GetComponent<CurrentAvatarDescription>().spriteId;
        Debug.Log(currentFaceId);

        foreach(var face in GetComponent<AvatarPartsCollection>().faceShapes)
        {
            if(face.spriteId == currentFaceId)
            {
                if(face.colour == GetComponent<CategorySelection>().currentSkinColour)
                {
                    faceSprite.GetComponent<SpriteRenderer>().sprite = face.spriteObject;
                    return;
                }
            }
        }
    }

    void ChangeBodyToMatchSkin()
    {
        //Query a list by number
        //Look for the skin colour
        GameObject faceSprite = GameObject.FindGameObjectWithTag("MainAvatar").transform.Find(spriteType.body.ToString()).gameObject;
        int currentFaceId = faceSprite.GetComponent<CurrentAvatarDescription>().spriteId;
        Debug.Log(currentFaceId);

        foreach (var face in GetComponent<AvatarPartsCollection>().bodies)
        {
            if (face.spriteId == currentFaceId)
            {
                if (face.colour == GetComponent<CategorySelection>().currentSkinColour)
                {
                    faceSprite.GetComponent<SpriteRenderer>().sprite = face.spriteObject;
                    return;
                }
            }
        }
    }

    //Called externally
    public void SetUpArray(List<GameObject> newItemList)
    {
        avatarElements = new AvatarDescription[newItemList.Count];

        //Convert a list of game objects to an array of avatar descriptions
        for(int i=0; i<avatarElements.Length; i++)
        {
            avatarElements[i] = newItemList[i].GetComponent<AvatarDescription>();
        }


        Debug.Log(this.GetComponent<CategorySelection>().currentCategory.ToString());

        mainSprite = GameObject.FindGameObjectWithTag("MainAvatar").transform.Find(this.GetComponent<CategorySelection>().currentCategory.ToString()).gameObject;
    }
}
