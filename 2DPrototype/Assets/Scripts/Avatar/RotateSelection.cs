using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script is attached to the empty game object named manager

public class RotateSelection : MonoBehaviour {

    //Array of avatar elements which can be selected
    public AvatarDescription[] avatarElements;

    //Main avatar sprite, which is changed 
    public GameObject mainSprite;

    //Name of the avatar part
    public string avatarPart = "AvatarFace";


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

        //Establish connection to the selected sprite part
        mainSprite = GameObject.FindGameObjectWithTag("MainAvatar").transform.Find(avatarPart).gameObject;

        //Set initial sprite on bike value

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
            //Set sprite
            mainSprite.GetComponent<SpriteRenderer>().sprite = avatarElements[currentSelectedSprite].getSprite();
            currentVerticalProgress = 0.1f;
            verticalSelectionActive = false;

            //Return bike to the beginning
            bike.transform.position = initialBikePos;


            //Skin colour REDO
            if (avatarElements[currentSelectedSprite].dye !=spriteColour.none)
            {
                this.GetComponent<CategorySelection>().currentSkinColour = avatarElements[currentSelectedSprite].dye;
            }

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

        //TEMP: change main sprite
        //mainSprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSelectedSprite];
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
    }
}
