using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamTexDriver : MonoBehaviour
{
    IEnumerator Start()
    {
        Application.RequestUserAuthorization(UserAuthorization.WebCam);

        // get front facing camera name.
        var devices = WebCamTexture.devices;
        var frontFacingDeviceName = string.Empty;
        foreach (var d in devices)
        {
            if (!d.isFrontFacing)
            {
                continue;
            }
            frontFacingDeviceName = d.name;
        }

        var webCamSize = 100;

        // request 100 x 100 size.
        var webCamTex = new WebCamTexture(frontFacingDeviceName, webCamSize, webCamSize, 10);
        webCamTex.Play();

        while (webCamTex.width == 16)
        {
            yield return null;
        }

        var w = webCamTex.width;
        var h = webCamTex.height;


        Debug.Log("w:" + w + " h:" + h);

        if (500 < w)
        {
            Debug.LogWarning("w and h is too large, in Unity 2017.4, iPad Pro 12.9inch 2018ver returns 300 x 400. but in Unity 2018.3 and later returns 2000 x 2700. this is maximum size. request does not effect.");
        }
    }

}
