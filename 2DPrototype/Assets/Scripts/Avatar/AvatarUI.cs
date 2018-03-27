using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAdventureBtnClick()
    {
        //Money manager
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MoneyManager"));

        SceneManager.LoadScene("mathsQuestions");
    }
}
