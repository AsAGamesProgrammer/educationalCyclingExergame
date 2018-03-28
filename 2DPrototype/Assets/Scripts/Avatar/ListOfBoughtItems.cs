using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfBoughtItems : MonoBehaviour {

    //Singleton
    private static bool created = false;

    //List which hold bought items
    //TODO: make define size by script
    public bool[] boughtFaceShape;
    bool[] boughtHairrDye;
    bool[] boughtHairUp;
    bool[] boughtHairDown;
    bool[] boughtNose;
    bool[] boughtMouth;
    bool[] boughtEyes;
    bool[] boughtBody;
    bool[] boughtSkin;

    // Use this for initialization
    void Awake ()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            //Ugly initialization
            boughtFaceShape = new bool[] {true, false, false, false, false, false, false, false };
            boughtHairrDye = new bool[] { true, false, false, false, false, false, false, false };
            boughtHairUp = new bool[] {true, false, false, false, false, false, false, false };
            boughtHairDown = new bool[] {true, false, false, false, false, false, false, false };
            boughtNose = new bool[] { true, false, false, false, false, false, false, false };
            boughtMouth = new bool[] { true, false, false, false, false, false, false, false };
            boughtEyes = new bool[] { true, false, false, false, false, false, false, false };
            boughtBody = new bool[] { true, false, false, false, false, false, false, false };
            boughtSkin= new bool[] { true, true, true};
        }
    }
	
    //Return respective array
    public bool[] GetArrayFromCategory(spriteType type)
    {
        switch (type)
        {
            case spriteType.faceShape:
                return boughtFaceShape;

            case spriteType.eyes:
                return boughtEyes;

            case spriteType.mouth:
                return boughtMouth;

            case spriteType.nose:
                return boughtNose;

            case spriteType.body:
                return boughtBody;

            case spriteType.hairColour:
                return boughtHairrDye;

            case spriteType.hairUp:
                return boughtHairUp;

            case spriteType.hairDown:
                return boughtHairDown;

            case spriteType.skin:
                return boughtSkin;

            default:
                break;
        }

        return null;
    }

    //Add item
    public void AddItemToCategory(spriteType type, int idNumber)
    {
        switch (type)
        {
            case spriteType.faceShape:
                boughtFaceShape[idNumber] = true;
                break;

            case spriteType.eyes:
                boughtEyes[idNumber] = true;
                break;

            case spriteType.mouth:
                boughtMouth[idNumber] = true;
                break;

            case spriteType.nose:
                boughtNose[idNumber] = true;
                break;

            case spriteType.body:
                boughtBody[idNumber] = true;
                break;

            case spriteType.hairColour:
                boughtHairrDye[idNumber] = true;
                break;

            case spriteType.hairUp:
                boughtHairUp[idNumber] = true;
                break;

            case spriteType.hairDown:
                boughtHairDown[idNumber] = true;
                break;

            case spriteType.skin:
                boughtSkin[idNumber] = true;
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
