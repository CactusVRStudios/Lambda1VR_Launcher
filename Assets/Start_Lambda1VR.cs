using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;


public class Start_Lambda1VR : MonoBehaviour
{

    public Button hlButton;
    public Button bsButton;
    public Button ofButton;   
    public Button hlGoldButton; //add more buttons here If needed 
    public Button mod1Button;
    public Button mod2Button;
    public Button mod3Button;
    public Button mod4Button;
    public Button mod5Button;  

    public Slider SSSlider;
    public Slider MSAA;
    public Slider CPU;
    public Slider GPU;
    public Text Failtext;
    public Text Divider;
    private int counter;

    void Start()
    {
        counter = 0;
        //Check what game is even installed
        if (Directory.Exists("/sdcard/xash/valve"))                   //check for folders
        {
            hlButton.gameObject.SetActive(true);
            RawImage hllogo = GetComponentInChildren<RawImage>();
            hllogo.gameObject.SetActive(true);
            hlButton.onClick.AddListener(delegate { TaskOnClick("valve"); });
            counter = 1;
        }

        if (Directory.Exists("/sdcard/xash/HL_Gold_HD"))                   
        {
            hlGoldButton.gameObject.SetActive(true);
            RawImage hllogo = GetComponentInChildren<RawImage>();
            hllogo.gameObject.SetActive(true);
            hlGoldButton.onClick.AddListener(delegate { TaskOnClick("HL_Gold_HD"); });
            counter = 1;
        }

        if (Directory.Exists("/sdcard/xash/bshift"))
        {        
            bsButton.gameObject.SetActive(true);
            RawImage bslogo = GetComponentInChildren<RawImage>();
            bslogo.gameObject.SetActive(true);
            bsButton.onClick.AddListener(delegate { TaskOnClick("bshift"); });
            counter = 1;
        }

        if (Directory.Exists("/sdcard/xash/gearbox"))
        {
            ofButton.gameObject.SetActive(true);
            RawImage oflogo = GetComponentInChildren<RawImage>();
            oflogo.gameObject.SetActive(true);
            ofButton.onClick.AddListener(delegate { TaskOnClick("gearbox"); });
            counter = 1;
        }

        if (counter == 0)
        {
            Failtext.gameObject.SetActive(true);
        }


        string[] customgames = Directory.GetDirectories("/sdcard/xash");
        int game = 0;
        foreach (string cgame in customgames)
        {
            //Debug.Log(Path.GetFileName(cgame));            
            if (Path.GetFileName(cgame) != "gearbox" & Path.GetFileName(cgame) != "valve" & Path.GetFileName(cgame) != "bshift" & Path.GetFileName(cgame) != "HL_Gold_HD")
            {
                if (game == 0)
                {
                    mod1Button.gameObject.SetActive(true);
                    Divider.gameObject.SetActive(true);
                    mod1Button.GetComponentInChildren<Text>().text = Path.GetFileName(cgame);
                    mod1Button.onClick.AddListener(delegate { TaskOnClick(Path.GetFileName(cgame)); });                    
                }

                if (game == 1)
                {
                    mod2Button.gameObject.SetActive(true);
                    mod2Button.GetComponentInChildren<Text>().text = Path.GetFileName(cgame);                    
                    mod2Button.onClick.AddListener(delegate { TaskOnClick(Path.GetFileName(cgame)); });                    
                }

                if (game == 2)
                {
                    mod3Button.gameObject.SetActive(true);
                    mod3Button.GetComponentInChildren<Text>().text = Path.GetFileName(cgame);
                    mod3Button.onClick.AddListener(delegate { TaskOnClick(Path.GetFileName(cgame)); });                    
                }

                if (game == 3)
                {
                    mod4Button.gameObject.SetActive(true);
                    mod4Button.GetComponentInChildren<Text>().text = Path.GetFileName(cgame);
                    mod4Button.onClick.AddListener(delegate { TaskOnClick(Path.GetFileName(cgame)); });                    
                }

                if (game == 5)
                {
                    mod5Button.gameObject.SetActive(true);
                    mod5Button.GetComponentInChildren<Text>().text = Path.GetFileName(cgame);
                    mod5Button.onClick.AddListener(delegate { TaskOnClick(Path.GetFileName(cgame)); });                    
                }

                game++;  //next game
            }

        }





}





    void TaskOnClick(string gamemode)
    {
        //Debug.Log("xash3d --supersampling " + SSSlider.value + " --msaa " + MSAA.value + " --cpu " + CPU.value + " --GPU " + GPU.value + " -game HL_Gold_HD");

        //Debug.Log("Game loaded " + gamemode);

        StreamWriter writer = new StreamWriter("/sdcard/xash/commandline.txt", false);
        writer.WriteLine("xash3d --supersampling " + SSSlider.value + " --msaa " + MSAA.value + " --cpu " + CPU.value + " --gpu " + GPU.value + " -game "  + gamemode);
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
