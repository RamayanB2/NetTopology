using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NameChanger : MonoBehaviour {

    public UnityEngine.UI.InputField inputField;
    string actual_name;

    public DragAndDropItem ptt_original;
    // Use this for initialization
    void Start () {
        inputField.text = "";
        actual_name = "";
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void ChangeName()
    {
        if (inputField.text != "" && inputField.text != actual_name) {
            actual_name = inputField.text;
            ptt_original.setName(actual_name);
            Debug.Log("NAMECHANGED");
        }
    }
}
