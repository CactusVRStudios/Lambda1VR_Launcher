using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Start_HL1_Bshift : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.gameObject.GetComponentInChildren<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        StreamWriter writer = new StreamWriter("/sdcard/xash/commandline.txt", false);
        writer.WriteLine("xash3d -log -dev 3 -log -game bshift");
        writer.Close();


        bool fail = false;
        string bundleId = "com.drbeef.lambda1vr"; // your target bundle id
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
        { //open app in store
            Application.OpenURL("https://sidequest.com");
        }
        else //open the app
            ca.Call("startActivity", launchIntent);

        up.Dispose();
        ca.Dispose();
        packageManager.Dispose();
        launchIntent.Dispose();

    }
}