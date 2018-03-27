using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManagerDuplicate : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //Finds all the objects tagged as Money manager
        GameObject[] moneyManagers = GameObject.FindGameObjectsWithTag("MoneyManager");

        //If there are duplicates
        if (moneyManagers.Length > 1)
        {
            //Delet all the old copies
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
