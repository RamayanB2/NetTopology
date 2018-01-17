using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Settings : MonoBehaviour {

    public int number_of_slots;//111 normal, 209 maior,
    public bool show_slots;
    int max_slots;

    public Sprite slot_nocell;
    public Sprite slot_cell;

    int slot_widht_height;

    public GameObject slots_area;
    //public BarOptionsSlider icons_area;
    public DragAndDropCell cell;

    int screenShoot_num;
    int actual_size;
    bool painel_options_on;
    public GameObject painel_options;
    public UnityEngine.UI.Text pathLabel;
    public UnityEngine.UI.Text avisoPath;
    public UnityEngine.UI.Image avisoExtPanel;
    public GameObject painelBlockTopo;
    public UnityEngine.UI.InputField pathInput;
    public Color color_save_bg;

    private ItemController item_controller;

    [SerializeField] bool reseting_bg;
    [SerializeField] float timer_to_reset;
    Color bg_Color;

    // Use this for initialization
    void Start () {
        pathLabel.text = PlayerPrefs.GetString("pathToSaveScreen", "C://Users//Public//Pictures//");       
        actual_size = 0;
        max_slots = 300;
        painel_options_on = true;
        TooglePainelOptions();
        screenShoot_num = PlayerPrefs.GetInt("screenShoot_num", 0); 
        InstantiateSlotsCheckSize(number_of_slots);
        reseting_bg = false;
        timer_to_reset = 5;
        avisoExtPanel.GetComponent<Animation>()["inout"].speed = 0.3f;
        item_controller = FindObjectOfType<ItemController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (reseting_bg) {
            timer_to_reset -= Time.deltaTime;            
            if (timer_to_reset <= 0)
            {
                slots_area.GetComponent<Image>().color = bg_Color;
                ToogleShowSlots();
                reseting_bg = false;
            }
        }
    }

    void InstantiateSlotsCheckSize(int num) {
        if (num <= 104)
        {
            slot_widht_height = 100;
            slots_area.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(100, 100);
            cell.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(100, 100);
            InstantiateSlots(num);
        }
        else if (num <= 143){
            slot_widht_height = 80;
            slots_area.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(80, 80);
            cell.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(80, 80);
            InstantiateSlots(num);
        }
        else if (num <= 263 && slot_widht_height > 60) {
            slots_area.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(60,60);
            cell.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(60,60);
            slot_widht_height = 60;
            InstantiateSlots(num);
        }
    }

    void InstantiateSlots(int num) {
        if (num <= max_slots) {
            for (int j = 0; j < num; j++){
                DragAndDropCell dpdc = Instantiate(cell, Vector3.one, Quaternion.identity);
                dpdc.transform.parent = slots_area.transform;
                dpdc.transform.localScale = Vector3.one;
            }
        }
        
    }

    public void CleanSlots(Button b) {
        b.GetComponent<Animation>().Play("Rotate");
        int childs = slots_area.transform.childCount;
        GameObject g;
        for (int i = childs - 1; i >= 0; i--){
            g = slots_area.transform.GetChild(i).gameObject;
            if (g.transform.childCount == 1) GameObject.Destroy(g.transform.GetChild(0).gameObject);
        }
    }

    public void ResetSlots() {        
        int childs = slots_area.transform.childCount;
        for (int i = childs - 1; i > 0; i--){
            GameObject.Destroy(slots_area.transform.GetChild(i).gameObject);
        }
    }

    public void ToogleShowSlots() {
        item_controller.SetIsShowingItemText(show_slots);
        painelBlockTopo.SetActive(show_slots);
        //item_controller.SetTextColorBlack(show_slots);
        show_slots = !show_slots;
        if (show_slots)ChangeSlots(slot_cell);
        else ChangeSlots(slot_nocell);
    }

    void ChangeSlots(Sprite uimask){
        foreach (Transform child in slots_area.transform){
            child.GetComponent<Image>().sprite = uimask;
        }
    }

    public void TooglePainelOptions() {
        painel_options_on = !painel_options_on;
        painel_options.gameObject.SetActive(painel_options_on);
        avisoPath.text = "";
    }

    public void SwichtSize(Button b) {
        b.GetComponent<Animation>().Play("Rotate");
        if (actual_size < 2) actual_size++;
        else actual_size = 0;
        if (actual_size == 0)
        {
            number_of_slots = 104;
            ResetSlots();
            InstantiateSlotsCheckSize(104);
        }
        else if (actual_size == 1)
        {
            number_of_slots = 143;
            ResetSlots();
            InstantiateSlotsCheckSize(143);
        }
        else if (actual_size == 2)
        {
            number_of_slots = 263;
            ResetSlots();
            InstantiateSlotsCheckSize(263);
        }
    }

    public void ChangeSaveImagePath() {
        this.pathLabel.text = this.pathInput.text;
        if (Directory.Exists(pathLabel.text)){
            PlayerPrefs.SetString("pathToSaveScreen", pathLabel.text);
            avisoPath.text = "Valid directory. Saved.";
            avisoPath.color = Color.gray;
        }
    }

    public void TakeScreenShoot(){
        if (Application.platform != RuntimePlatform.Android){
        timer_to_reset = 5;
        ToogleShowSlots();
        bg_Color = slots_area.GetComponent<Image>().color;
        slots_area.GetComponent<Image>().color = color_save_bg;
            if (Directory.Exists(pathLabel.text))
            {
                ScreenCapture.CaptureScreenshot(pathLabel.text + "/NetTopology_ScreenShoot_" + screenShoot_num + ".png");
                screenShoot_num++;
                PlayerPrefs.SetInt("screenShoot_num", screenShoot_num);
                avisoExtPanel.GetComponent<Animation>().Play("inout");
            }
            else {
                avisoExtPanel.GetComponentInChildren<Text>().text = "Invalid Directory";
                avisoExtPanel.GetComponent<Animation>().Play("inout");
                avisoPath.text = "Invalid path. Please change select type a valid directory path.";
                avisoPath.color = Color.red;
            }
        reseting_bg = true;
        Debug.Log("FOTO TIRADA");
        }
    }

    public void GoToContactMeForm(){
        Application.OpenURL("https://goo.gl/forms/35Qvh6ytXkt9Vdmt2");
    }
}
