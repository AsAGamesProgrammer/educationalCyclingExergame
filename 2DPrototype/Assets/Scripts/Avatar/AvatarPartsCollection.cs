using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/// <summary>
/// TARGET: Empty game object - Manager, 
///         which has AvatarPartCollection, CategorySelection and RotateSelection scripts attached
/// PURPOSE: - Convert avatar sprites from the asset folder to SpriteInstance objects position those in the correct 
///          - Position converted SpriteInstances into respective lists
/// </summary>
public class AvatarPartsCollection : MonoBehaviour {

    public List<SpriteInstance> faceShapes = new List<SpriteInstance>();
    public List<SpriteInstance> skinColours = new List<SpriteInstance>();
    public List<SpriteInstance> hairColours = new List<SpriteInstance>();
    public List<SpriteInstance> hairUp = new List<SpriteInstance>();
    public List<SpriteInstance> hairDown = new List<SpriteInstance>();
    public List<SpriteInstance> bodies = new List<SpriteInstance>();
    public List<SpriteInstance> eyes = new List<SpriteInstance>();
    public List<SpriteInstance> noses = new List<SpriteInstance>();
    public List<SpriteInstance> mouths = new List<SpriteInstance>();

    // Use this for initialization
    [MenuItem("AssetDatabase/2DPrototype")]

    void Start ()
    {
        string[] folders = new string[9];
        folders[0] = "Assets/VisualAssets/AvatarElements/FaceShape";
        folders[1] = "Assets/VisualAssets/AvatarElements/SkinColour";
        folders[2] = "Assets/VisualAssets/AvatarElements/Body";
        folders[3] = "Assets/VisualAssets/AvatarElements/Eyes";
        folders[4] = "Assets/VisualAssets/AvatarElements/HairColour";
        folders[5] = "Assets/VisualAssets/AvatarElements/HairDown";
        folders[6] = "Assets/VisualAssets/AvatarElements/HairUp";
        folders[7] = "Assets/VisualAssets/AvatarElements/Mouth";
        folders[8] = "Assets/VisualAssets/AvatarElements/Nose";


        var paths = AssetDatabase.FindAssets("t:Sprite", folders);
        foreach (string guid in paths)
        {
            //Load sprite from path to a list
            LoadSprite(guid);
        }
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

        //ID
        newInstance.spriteId = int.Parse(components[1]);

        //Assign sprite object
        newInstance.spriteObject = (Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(path), typeof(Sprite));

        //Switch depending on the avatar part
        AssignToListByType(components[0], components[2], newInstance);
    }

    //Colour switch
    spriteColour GetSkinColourFromComponent(string word)
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

    //Get hair colour
    spriteColour GetHairColourFromComponent(string word)
    {
        switch (word)
        {
            case "White":
                return spriteColour.hairWhite;

            case "Blue":
                return spriteColour.hairBlue;

            case "Brown":
                return spriteColour.hairBrown;

            case "Ginger":
                return spriteColour.hairOrange;

            case "Pink":
                return spriteColour.hairPink;

            default:
                return spriteColour.none;
        }
    }

    //Type switch
    void AssignToListByType(string word, string colour, SpriteInstance instance)
    {
        switch (word)
        {
            case "Face":
                instance.type = spriteType.faceShape;
                instance.colour = GetSkinColourFromComponent(colour);
                faceShapes.Add(instance);
                return;

            case "SkinColour":
                instance.type = spriteType.skin;
                instance.colour = GetSkinColourFromComponent(colour);
                skinColours.Add(instance);
                return;

            case "Body":
                instance.type = spriteType.body;
                instance.colour = GetSkinColourFromComponent(colour);
                bodies.Add(instance);
                return;

            case "Eyes":
                instance.type = spriteType.eyes;
                instance.colour = spriteColour.none;
                eyes.Add(instance);
                return;

            case "HairColour":
                instance.type = spriteType.hairColour;
                instance.colour = GetHairColourFromComponent(colour);
                hairColours.Add(instance);
                return;

            case "HairDown":
                instance.type = spriteType.hairDown;
                instance.colour = GetHairColourFromComponent(colour);
                hairDown.Add(instance);
                return;

            case "HairUp":
                instance.type = spriteType.hairUp;
                instance.colour = GetHairColourFromComponent(colour);
                hairUp.Add(instance);
                return;

            case "Mouth":
                instance.type = spriteType.mouth;
                instance.colour = spriteColour.none;
                mouths.Add(instance);
                return;

            case "Nose":
                instance.type = spriteType.nose;
                instance.colour = spriteColour.none;
                noses.Add(instance);
                return;

            default:
                instance.type = spriteType.none;
                instance.colour = spriteColour.none;
                return;
        }
    }
}

//---------------HELPER CLASSES----------------
[System.Serializable]
public class SpriteInstance
{
    public Sprite spriteObject;
    public spriteColour colour;
    public spriteType type;
    public int spriteId = -1;
}

public enum spriteType
{
    faceShape,
    skin,
    hairUp,
    hairDown,
    hairColour,
    nose,
    mouth,
    eyes,
    body,
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

