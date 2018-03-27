using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour {

    public int balance = 0;
    public bool isNewest = false;

    //UI
    public Text balanceText;

    // Use this for initialization
    void Start ()
    {
        //Get gui component
        balanceText = GameObject.FindGameObjectWithTag("BalanceText").GetComponent<Text>();

        balanceText.text = balance.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(balanceText == null)
        {
            balanceText = GameObject.FindGameObjectWithTag("BalanceText").GetComponent<Text>();
            balanceText.text = balance.ToString();
        }
	}

    public void addMoney (int money)
    {
        balance += money;
        balanceText.text = balance.ToString();
    }

    public int getBalance()
    {
        return balance;
    }
}
