using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;


public class Start_Custom : MonoBehaviour
{
    public Button yourButton;
    public TMP_InputField customLine;

    void Start()
    {
        Button btn = yourButton.gameObject.GetComponentInChildren<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {


        //Debug.Log((customLine.text);


        StreamWriter writer = new StreamWriter("/sdcard/xash/commandline.txt", false);
        writer.WriteLine(customLine.text);
        writer.Close();


        bool fail = false;
        string bundleId = "com.drbeef.lambda1vr"; // starting lambda1vr
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

        AndroidJavaObject launchIntent = null;
        try
        {
            launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleId);
        }
        catch (System.Exception)
        {
            fail = true;
        }

        if (fail)
        { //open sidequest in browser
            Application.OpenURL("https://sidequest.com");
        }
        else //open lambda1vr
            ca.Call("startActivity", launchIntent);

        up.Dispose();
        ca.Dispose();
        packageManager.Dispose();
        launchIntent.Dispose();

    }
}
