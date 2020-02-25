using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class easter : MonoBehaviour
{

    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "EasterBox" ^ collision.gameObject.name == "EasterBox2")

        {
            StartCoroutine(PlayVideo());
        }
        
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        videoPlayer.isLooping = true;

    }
}
