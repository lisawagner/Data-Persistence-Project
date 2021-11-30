using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayText : MonoBehaviour
{
    public Text obj_text;
    public InputField display;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj_text.text = PlayerPrefs.GetString("user_name");
    }

    public void Create()
    {
        obj_text.text = display.text;
        PlayerPrefs.SetString("user_name", obj_text.text);
        PlayerPrefs.Save();
    }
}
