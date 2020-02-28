using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class createcommandline : MonoBehaviour
{

    public TMP_InputField customLine;
    public Text statusLine;

    public Slider SSSlider;
    public Slider MSAA;
    public Slider CPU;
    public Slider GPU;

    void Start()
    {
        Button newlineButton = GetComponent<Button>();
        newlineButton.onClick.AddListener(newLine);
    }

    void newLine()
    {
        customLine.text = "xash3d --supersampling " + SSSlider.value + " --msaa " + MSAA.value + " --cpu " + CPU.value + " --gpu " + GPU.value + " -game ";
        statusLine.text = "";
    }


}
