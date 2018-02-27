using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour {

    int balance = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addMoney (int money)
    {
        balance += money;
    }

    public int getBalance()
    {
        return balance;
    }
}
