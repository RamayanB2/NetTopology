using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    string itemName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayItemName()
    {
        Debug.Log("Mouse Over " + itemName);
        this.GetComponentInChildren<UnityEngine.UI.Text>().text = itemName;
    }

    public void HideItemName()
    {
        Debug.Log("Mouse Left " + itemName);
        this.GetComponentInChildren<UnityEngine.UI.Text>().text = "";
    }
}
