using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class readcmdlinetxt : MonoBehaviour
{
    public TMP_InputField customLine;


    // Start is called before the first frame update
    void Start()
    {
        StreamReader cmdfile = new StreamReader("/sdcard/xash/commandline.txt");
        customLine.text = cmdfile.ReadLine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
