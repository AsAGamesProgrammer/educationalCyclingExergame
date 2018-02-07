using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateSelection : MonoBehaviour {

    public Sprite [] sprites;
    public GameObject[] spritePositions;
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
        if(Input.GetAxis("Vertical") >0.05f && mainSprite.GetComponent<SpriteRenderer>().sprite != sprites[currentSelectedSprite])
        {
            verticalSelectionActive = true;

            VerticalSelection();
        }
    }

    void VerticalSelection()
    {
        if (currentVerticalProgress < progressToUnlock)
        {
            //Debug
            Debug.Log(currentVerticalProgress);

            //Add current spinning value
            currentVerticalProgress += Input.GetAxis("Vertical");

            //Move bike
            bike.transform.position += Vector3.right * Input.GetAxis("Vertical") * extraSpeedModifier;
        }
        else
        {
            //Set sprite
            mainSprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSelectedSprite];
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
            if (currentSelectedSprite + 1 < sprites.Length)
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
                currentSelectedSprite = sprites.Length - 1;

            changeSpriteSelection = true;
        }

        return changeSpriteSelection;
    }

    //Respond to arrow key input to indicate which picture is selected
    void ChangeSelection()
    {
        //Move particles
        partS.transform.position = new Vector2(spritePositions[currentSelectedSprite].transform.position.x, -4.5f);

        //Set on bike sprite to a current selection only if it is npt applied yet
        if (mainSprite.GetComponent<SpriteRenderer>().sprite != sprites[currentSelectedSprite])
            spriteOnBike.GetComponent<SpriteRenderer>().sprite = sprites[currentSelectedSprite];
        else
            spriteOnBike.GetComponent<SpriteRenderer>().sprite = null;

        //TEMP: change main sprite
        //mainSprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSelectedSprite];
    }
}
