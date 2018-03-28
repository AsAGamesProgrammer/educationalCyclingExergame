using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TARGET: Each displayed sprite among the selectable items
/// PURPOSE: - Store information on price, ownership, dye etc.
/// 
/// 
/// PRICES:
/// Hair dye = 500 each
/// Nose, eyes, mouth = 5 * id
/// Hair = 350 * id
/// Body = 1000 * id
/// </summary>

public class AvatarDescription : MonoBehaviour {

    public int price = 0;
    public bool isOwned = false;

    //Indicates if applying this sprite should change current colour for any category
    public spriteColour SkinDye = spriteColour.none;
    public spriteColour HairDye = spriteColour.none;

    public int spriteId = -1;

    private void Awake()
    {
        //Own the first item
        //if (spriteId < 2)
        //{
        //    Debug.Log("Changed zero item to be owned");
        //    isOwned = true;
        //}
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
