using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManagerDuplicate : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameObject[] moneyManagers = GameObject.FindGameObjectsWithTag("MoneyManager");

        if (moneyManagers.Length > 1)
        {
            foreach (var manager in moneyManagers)
            {
                if (!manager.GetComponent<PlayerMoney>().isNewest)
                    Destroy(manager);
                else
                    manager.GetComponent<PlayerMoney>().isNewest = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
