﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AvatarPartsCollection : MonoBehaviour {

    public Sprite test;
    public List<SpriteInstance> faceShapes = new List<SpriteInstance>();

    // Use this for initialization
    [MenuItem("AssetDatabase/2DPrototype")]
    //[MenuItem("2DPrototype")]
    void Start ()
    {
        //test = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/VisualAssets/AvatarElements/FaceShape/Face2Dark.png", typeof(Sprite));
        string[] folders = new string[1];
        folders[0] = "Assets/VisualAssets/AvatarElements/FaceShape";


        var tests = AssetDatabase.FindAssets("t:Sprite", folders);
        foreach (string guid in tests)
        {

            //Load sprite from path to a list
            LoadSprite(guid);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadSprite(string path)
    {
        //Debug
        Debug.Log(AssetDatabase.GUIDToAssetPath(path));

        //Split name to components
        string[] components = path.Split(' ');

        //Sprite instance
        SpriteInstance newInstance = new SpriteInstance();

        //Assign sprite object
        newInstance.spriteObject = (Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(path), typeof(Sprite));

        //
        newInstance.colour = spriteColour.skinWhite;
        newInstance.type = spriteType.faceShape;

        //Add to list
        faceShapes.Add(newInstance);
    }


}

//Helper classes
[System.Serializable]
public class SpriteInstance
{
    public Sprite spriteObject;
    public spriteColour colour;
    public spriteType type;

}

public enum spriteType
{
    faceShape,
    skin
}

[System.Serializable]
public enum spriteColour
{
    skinWhite,
    skinBrown,
    skinDark,
    hairWhite,
    hairPink,
    hairBlue,
    hairOrange,
    hairBrown
}

