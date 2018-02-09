using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AvatarPartsCollection : MonoBehaviour {

    public List<SpriteInstance> faceShapes = new List<SpriteInstance>();
    public List<SpriteInstance> skinColours = new List<SpriteInstance>();

    // Use this for initialization
    [MenuItem("AssetDatabase/2DPrototype")]

    void Start ()
    {
        string[] folders = new string[2];
        folders[0] = "Assets/VisualAssets/AvatarElements/FaceShape";
        folders[1] = "Assets/VisualAssets/AvatarElements/SkinColour";


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
        string[] fileName = AssetDatabase.GUIDToAssetPath(path).Split('/', '.');
 
        //Split file name to components
        string[] components = fileName[fileName.Length-2].Split(' ');

  

        //Sprite instance
        SpriteInstance newInstance = new SpriteInstance();

        //Assign sprite object
        newInstance.spriteObject = (Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(path), typeof(Sprite));

        //Switch depending on colour
        if(components.Length>2)
        {
            newInstance.colour = GetColourFromComponent(components[2]);
        }

        //Switch depending on the avatar part
        AssignToListByType(components[0], newInstance);
    }

    //Colour switch
    spriteColour GetColourFromComponent(string word)
    {
        switch (word)
        {
            case "White":
                return spriteColour.skinWhite;

            case "Med":
                return spriteColour.skinBrown;

            case "Dark":
                return spriteColour.skinDark;

            default:
                return spriteColour.none;
        }
    }

    //Type switch
    void AssignToListByType(string word, SpriteInstance instance)
    {
        switch (word)
        {
            case "Face":
                instance.type = spriteType.faceShape;
                faceShapes.Add(instance);
                return;

            case "SkinColour":
                instance.type = spriteType.skin;
                skinColours.Add(instance);
                return;

            default:
                instance.type = spriteType.none;
                return;
        }
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
    skin,
    none
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
    hairBrown,
    none
}

