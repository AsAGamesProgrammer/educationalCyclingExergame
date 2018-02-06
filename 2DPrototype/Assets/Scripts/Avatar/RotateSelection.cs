using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateSelection : MonoBehaviour {

    public Sprite [] sprites;
    public GameObject[] spritePositions;
    public GameObject mainSprite;
    public GameObject partS;
    private int currentSelectedSprite = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Check for input and change sprite selection
        if (HorizontalInputReceived())
            ChangeSelection();
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

        //TEMP: change main sprite
        mainSprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSelectedSprite];
    }
}
