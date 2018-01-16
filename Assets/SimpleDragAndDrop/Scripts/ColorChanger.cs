using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public DragAndDropItem[] setas_originais;
    public Color[] colors;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeColor(int j)
    {
        for (int i=0;i<setas_originais.Length;i++) {
            setas_originais[i].GetComponent<UnityEngine.UI.Image>().color = colors[j];
        }
    }
}
