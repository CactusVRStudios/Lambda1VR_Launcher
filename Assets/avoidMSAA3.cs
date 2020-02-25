using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avoidMSAA3 : MonoBehaviour
{

    public Slider MSAAslider;
    private Text textSliderValue;

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        if (MSAAslider.value == 3)
        {
            MSAAslider.value = 4;

        }
        string sliderMessage = "" + MSAAslider.value;
        textSliderValue.text = sliderMessage;
        
    }
}
