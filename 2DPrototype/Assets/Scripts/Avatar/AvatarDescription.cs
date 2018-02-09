using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Is attached to a selectable sprite

public class AvatarDescription : MonoBehaviour {

    public int price;
    public bool isOwned = false;

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
