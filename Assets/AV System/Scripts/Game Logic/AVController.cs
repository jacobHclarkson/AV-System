using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVController : MonoBehaviour {
    [SerializeField] GameObject webcamTexturePlane;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;


	void Start () {
		
	}
	
	void Update () {
        if (AVactive())
        {
            RenderSettings.fog = false;
            webcamTexturePlane.SetActive(true);
        }else
        {
            webcamTexturePlane.SetActive(false);
            RenderSettings.fog = true;
        }
	}

    bool AVactive()
    {
        if(leftHand.activeSelf || rightHand.activeSelf)
        {
            return true;
        }else
        {
            return false;
        }
    }

    void ToggleFog()
    {
        if (RenderSettings.fog)
        {
            RenderSettings.fog = false;
        }
        else
        {
            RenderSettings.fog = true;
        }
    }
}
