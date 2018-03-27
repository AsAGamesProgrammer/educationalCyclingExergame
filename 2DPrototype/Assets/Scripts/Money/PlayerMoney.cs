using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour {

    public int balance = 0;
    public bool isNewest = false;

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
