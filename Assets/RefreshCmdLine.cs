using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class RefreshCmdLine : MonoBehaviour
{
    public TMP_InputField customLine;

    // Start is called before the first frame update
    void Start()
    {
        Button refreshButton = GetComponent<Button>();
        refreshButton.onClick.AddListener(refresh);
    }

    void refresh()
    {
        StreamReader cmdfile = new StreamReader("/sdcard/xash/commandline.txt");
        customLine.text = cmdfile.ReadLine();
    }
}
