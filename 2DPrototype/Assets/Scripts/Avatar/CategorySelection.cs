using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategorySelection : MonoBehaviour {

    public spriteColour currentSkinColour = spriteColour.skinBrown;
    private AvatarPartsCollection avatarCollection;

    public List<GameObject> selectableItems = new List<GameObject>();

    public spriteType currentCategory = spriteType.none;

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

        Debug.Log(currentCollection.Count);
        foreach(var item in currentCollection)
        {
            //Temp!!! Doesnt work for skin
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
        RepositionSelectionItems();

        //Upload Items to the selection script
        GetComponent<RotateSelection>().SetUpArray(selectableItems);
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
