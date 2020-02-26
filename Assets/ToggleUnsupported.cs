using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUnsupported : MonoBehaviour
{
    GameObject unsupportedGame;
    // Start is called before the first frame update
    void Start()
    {
        unsupportedGame = GameObject.Find("OtherGames");
    }

    public void ChangeValueToTrue()
    {
        unsupportedGame.SetActive(false);

    }

    public void ChangeValueToFalse()
    {


    }

}
