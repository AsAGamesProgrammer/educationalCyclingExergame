using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour {

    private static bool created = false;

    public bool MusicOn = true;
    public bool SFXOn = true;

    private void Awake()
    {
        //Singleton
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            // Do not destroy the object on loading new scene
            DontDestroyOnLoad(gameObject);
        }
    }
}
