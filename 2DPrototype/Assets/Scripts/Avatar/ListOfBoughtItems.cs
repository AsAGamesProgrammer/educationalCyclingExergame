using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfBoughtItems : MonoBehaviour {

    //Singleton
    private static bool created = false;

    //List which hold bought items
    List<int> boughtFaceShape = new List<int>();
    List<int> boughtHairrDye = new List<int>();
    List<int> boughtHairUp = new List<int>();
    List<int> boughtHairDown = new List<int>();
    List<int> boughtNose = new List<int>();
    List<int> boughtFaceMouth = new List<int>();
    List<int> boughtFaceEyes = new List<int>();
    List<int> boughtFaceBody = new List<int>();

    // Use this for initialization
    void Awake ()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
