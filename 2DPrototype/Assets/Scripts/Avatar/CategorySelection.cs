using System.Collections;
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
    public spriteColour currentHairColour = spriteColour.hairBlue;

    //Borders
    public GameObject rightBorder;
    public GameObject leftBorder;

    //Bought Items
    ListOfBoughtItems boughtItemScript;

	// Use this for initialization
	void Start ()
    {
        avatarCollection = GetComponent<AvatarPartsCollection>();

        boughtItemScript = GameObject.FindGameObjectWithTag("MoneyManager").GetComponent<ListOfBoughtItems>();
	}
	
    //CLICK on a category button
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

            case "skin":
                if (currentCategory != spriteType.skin)
                {
                    currentCategory = spriteType.skin;
                    CreateSelectionItems();
                }
                break;

            case "Eyes":
                if (currentCategory != spriteType.eyes)
                {
                    currentCategory = spriteType.eyes;
                    CreateSelectionItems();
                }
                break;

            case "Mouth":
                if (currentCategory != spriteType.mouth)
                {
                    currentCategory = spriteType.mouth;
                    CreateSelectionItems();
                }
                break;

            case "Nose":
                if (currentCategory != spriteType.nose)
                {
                    currentCategory = spriteType.nose;
                    CreateSelectionItems();
                }
                break;

            case "HairColour":
                if (currentCategory != spriteType.hairColour)
                {
                    currentCategory = spriteType.hairColour;
                    CreateSelectionItems();
                }
                break;

            case "HairUp":
                if (currentCategory != spriteType.hairUp)
                {
                    currentCategory = spriteType.hairUp;
                    CreateSelectionItems();
                }
                break;

            case "HairDown":
                if (currentCategory != spriteType.hairDown)
                {
                    currentCategory = spriteType.hairDown;
                    CreateSelectionItems();
                }
                break;

            case "Body":
                if (currentCategory != spriteType.body)
                {
                    currentCategory = spriteType.body;
                    CreateSelectionItems();
                }
                break;
        }
    }

    //CREATE ITEMS
    public void CreateSelectionItems()
    {
        //Clear list
        ClearCurrentList();

        //Obtain current collection from avatar collection scirpt
        List<SpriteInstance> currentCollection = ObtainCurrentCollection();

        foreach (var item in currentCollection)
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

                //POPULATE AVATAR DESCIPTION
                //Preowned TODO: REDO MONEY
                if(item.spriteId <2 && item.type !=spriteType.hairColour)
                {
                    Debug.Log("Changed" + item.spriteId + " item to be owned");
                    //Ownership
                    newItem.GetComponent<AvatarDescription>().isOwned = true;
                }
                    
                //Skin
                if(item.type==spriteType.skin)
                {
                    newItem.GetComponent<AvatarDescription>().SkinDye = item.colour;

                    //Ownership
                    newItem.GetComponent<AvatarDescription>().isOwned = true;
                }

                //Hair Dye
                if (item.type == spriteType.hairColour)
                {
                    newItem.GetComponent<AvatarDescription>().HairDye = item.colour;

                    //Price
                    newItem.GetComponent<AvatarDescription>().price = 500;

                    //Ownership
                    if(item.colour == spriteColour.hairBlue)
                        newItem.GetComponent<AvatarDescription>().isOwned = true;
                }

                //Nose, eyes, mouth
                if (item.type == spriteType.eyes || item.type == spriteType.nose || item.type == spriteType.mouth)
                {
                    //Price
                    newItem.GetComponent<AvatarDescription>().price = 5 * item.spriteId;
                }

                //Face shape
                if(item.type == spriteType.faceShape)
                {
                    //Price
                    newItem.GetComponent<AvatarDescription>().price = 50 * item.spriteId;
                }

                //Hair
                if (item.type == spriteType.hairDown|| item.type == spriteType.hairUp)
                {
                    //Price
                    newItem.GetComponent<AvatarDescription>().price = 350 * item.spriteId;
                }

                //Body
                if (item.type == spriteType.body)
                {
                    //Price
                    newItem.GetComponent<AvatarDescription>().price = 1000 * item.spriteId;
                }

                //Instantiate
                selectableItems.Add(newItem);
            }
        }

        //Bought items
        var boughtItems = boughtItemScript.GetArrayFromCategory(currentCategory);
        for (int i=0; i<selectableItems.Count; i++)
        {
            selectableItems[i].GetComponent<AvatarDescription>().isOwned = boughtItems[i];
        }

        //Reposition
        RepositionSelectionItems();

        //Upload Items to the selection script
        GetComponent<RotateSelection>().SetUpArray(selectableItems);

        //Reposition particles
        GetComponent<RotateSelection>().RepositionParticles();

        //Sprite on bike
        GetComponent<RotateSelection>().ChangeSelection();
    }

    //Remove all the items from the previous category
    void ClearCurrentList()
    {
        //Clear list
        foreach (var item in selectableItems)
        {
            Destroy(item);
        }
        selectableItems = new List<GameObject>();
    }

    //Depending on the current category get a collection of items
    List<SpriteInstance> ObtainCurrentCollection()
    {
        //Create empty list
        List<SpriteInstance> currentCollection = new List<SpriteInstance>();

        //Get one collection from avatar colelction script 
        switch (currentCategory)
        {
            case spriteType.faceShape:
                currentCollection = avatarCollection.faceShapes;
                break;

            case spriteType.skin:
                currentCollection = avatarCollection.skinColours;
                break;

            case spriteType.eyes:
                currentCollection = avatarCollection.eyes;
                break;

            case spriteType.mouth:
                currentCollection = avatarCollection.mouths;
                break;

            case spriteType.nose:
                currentCollection = avatarCollection.noses;
                break;

            case spriteType.body:
                currentCollection = avatarCollection.bodies;
                break;

            case spriteType.hairColour:
                currentCollection = avatarCollection.hairColours;
                break;

            case spriteType.hairUp:
                currentCollection = avatarCollection.hairUp;
                break;

            case spriteType.hairDown:
                currentCollection = avatarCollection.hairDown;
                break;

            default:
                break;
        }

        return currentCollection;
    }

    bool ItemIsValid(SpriteInstance item)
    {
        bool itemValidFlag = true;

        //Check skin colour
        if(item.type == spriteType.faceShape || item.type == spriteType.body)
        {
            if (item.colour != currentSkinColour)
            {
                itemValidFlag = false;
            }
        }

        //Check hair colour
        if (item.type == spriteType.hairDown || item.type == spriteType.hairUp)
        {
            if (item.colour != currentHairColour)
            {
                itemValidFlag = false;
            }
        }

        return itemValidFlag;
    }


    //Find deal position for N items
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
