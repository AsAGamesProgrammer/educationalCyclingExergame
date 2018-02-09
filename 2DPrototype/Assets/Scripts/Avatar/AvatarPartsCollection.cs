using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AvatarPartsCollection : MonoBehaviour {

    public SpriteInstance[] faces;
    public SpriteInstance[] skinColours;
    public Sprite test;
    //public Sprite[] tests;

    //public Dictionary<spriteColour, GameObject[]> faceShapes = new Dictionary<spriteColour, GameObject[]>();

    // Use this for initialization
    [MenuItem("AssetDatabase/2DPrototype")]
    //[MenuItem("Example/FindAssets Example")]
    void Start ()
    {
        test = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/VisualAssets/AvatarElements/FaceShape/Face2Dark.png", typeof(Sprite));

       
        var tests = AssetDatabase.FindAssets("t:Sprite");
        foreach (string guid in tests)
        {
            Debug.Log("testI: " + AssetDatabase.GUIDToAssetPath(guid));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}

//Helper classes
[System.Serializable]
public class SpriteInstance
{
    public GameObject spriteObject;
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

