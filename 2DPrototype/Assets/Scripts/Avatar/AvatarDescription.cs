using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TARGET: Each displayed sprite among the selectable items
/// PURPOSE: - Store information on price, ownership, dye etc.
/// </summary>

public class AvatarDescription : MonoBehaviour {

    public int price;
    public bool isOwned = false;

    //Indicates if applying this sprite should change current colour for any category
    public spriteColour dye = spriteColour.none;

    //ADD 
    //colour (for dyes)
    //layer

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Public getters used by other scripts
    public Sprite getSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public Vector2 getPosition()
    {
        return transform.position;
    }
}
