using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    string itemName;
    public bool isShowingItemText;
    public bool isColorBlack;

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

    public void SetIsShowingItemText(bool b) {
        isShowingItemText = b;
    }

    public void ToogleShowHideAllItensNames() {
        isShowingItemText = !isShowingItemText;
    }

    public void SetTextColorBlack(bool b) {
        isColorBlack = b;
    }

}
