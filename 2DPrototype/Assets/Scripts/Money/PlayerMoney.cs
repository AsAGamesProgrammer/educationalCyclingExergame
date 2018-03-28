using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour {

    int balance = 0;

    //Flag used to remove duplicates
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
        //After scene changed and the object was not destroyed refind the component
		if(balanceText == null)
        {
            //Find game object
            balanceText = GameObject.FindGameObjectWithTag("BalanceText").GetComponent<Text>();

            //Display current balance
            balanceText.text = balance.ToString();
        }
	}

    //ADD MONEY
    public void addMoney (int money)
    {
        balance += money;
        balanceText.text = balance.ToString();
    }

    //REMOVE MONEY
    public void pay(int money)
    {
        balance -= money;
        balanceText.text = balance.ToString();
    }

    //RETURN VALUE
    public int getBalance()
    {
        return balance;
    }
}
