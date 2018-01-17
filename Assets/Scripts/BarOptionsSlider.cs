using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BarOptionsSlider : MonoBehaviour {

    public float speed;
    float max_speed;
    [SerializeField]bool movingLeft;
    [SerializeField] bool movingRight;
    [SerializeField] bool stoping;
    [SerializeField] float timer_to_stop;//drift effect brake effect
    [SerializeField] float speed_change;

    private ItemController itemController;

    // Use this for initialization
    void Start () {
        max_speed = 20;
        timer_to_stop = 3;
        speed_change = speed;
        itemController = FindObjectOfType <ItemController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (movingLeft) transform.position += Vector3.left * Time.deltaTime * speed_change * 5;
        if (movingRight) transform.position += Vector3.right * Time.deltaTime * speed_change * 5;
        if (stoping){
            timer_to_stop -= Time.deltaTime;
            if(speed>0)speed_change -= Time.deltaTime * 5;
            if (timer_to_stop <= 0)
            {
                movingLeft = false;
                movingRight = false;
                stoping = false;
                speed_change = speed;
            }
        }       
    }

    public void MoveLeft() {
        movingLeft = true;
        movingRight = false;
        Debug.Log("LEFTTTT");
    }

    public void MoveRight(){
        movingLeft = false;
        movingRight = true;
        Debug.Log("rIGHT");
    }

    public void StopMoving()
    {
        timer_to_stop = 3;
        stoping = true;
        Debug.Log("STOP");
    }

    public void ShowAllIconNames() {
        itemController.SetIsShowingItemText(true);
    }

    public void HideAllIconNames(){
        itemController.SetIsShowingItemText(false);
    }

    public void ToogleShowHideAllItensNames() {
        itemController.ToogleShowHideAllItensNames();
    }

    public void DoNothing() {
    }
    
}
