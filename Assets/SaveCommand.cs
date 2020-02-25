using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class SaveCommand : MonoBehaviour
{
    public Button yourButton;
    public TMP_InputField customLine;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.gameObject.GetComponentInChildren<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        
        //Debug.Log((customLine.text);
        StreamWriter writer = new StreamWriter("/sdcard/xash/launchersave.txt", true);
       
        writer.WriteLine(customLine.text,writer.NewLine);
        writer.Close();


    }
}
