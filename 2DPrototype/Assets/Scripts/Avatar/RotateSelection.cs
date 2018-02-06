using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateSelection : MonoBehaviour {

    public Sprite [] sprites;
    public GameObject mainSprite;
    private int currentSelectedSprite = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float horizontal = Input.GetAxis("Horizontal");

        //ARROW RIGHT
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSelectedSprite + 1 < sprites.Length)
                currentSelectedSprite++;
            else
                currentSelectedSprite = 0;

            mainSprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSelectedSprite];
        }

        //ARROW LEFT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelectedSprite >0)
                currentSelectedSprite--;
            else
                currentSelectedSprite = sprites.Length-1;

            mainSprite.GetComponent<SpriteRenderer>().sprite = sprites[currentSelectedSprite];
        }

    }
}
