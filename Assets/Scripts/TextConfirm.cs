using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextConfirm : MonoBehaviour
{
    public static TextConfirm instance;
    //public string checkText;

    private void Awake()
    {
       instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        //textDebug = this.transform.GetComponent<TextMeshPro>().text;
    }

    public void TextTextDebug(string debugText)
    {
        this.transform.GetComponent<TextMeshPro>().text = debugText;
    }
}
