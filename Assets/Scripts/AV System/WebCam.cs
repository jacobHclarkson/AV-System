using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour {

    WebCamDevice[] devices;
    WebCamTexture webCamTexture;
    public Color32[] data;

	void Start () {
        devices = WebCamTexture.devices;
        

        // look for correct webcam and assign texture
        for(int i=0; i<devices.Length; i++)
        {
            if(devices[i].name == "Logitech Webcam C930e")
            {
                webCamTexture = new WebCamTexture("Logitech Webcam C930e", 960, 480, 60);
                
            }
        }
 
        GetComponent<Renderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
        data = new Color32[webCamTexture.width * webCamTexture.height];
    }

    void Update()
    {
        if (webCamTexture.didUpdateThisFrame)
        {
            webCamTexture.GetPixels32(data);
        }
    }
}
