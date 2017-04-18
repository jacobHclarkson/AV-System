using UnityEngine;
using System.Collections;

public class InteractiveCue : MonoBehaviour {

    [SerializeField] VRStandardAssets.Utils.VREyeRaycaster eyeRayCaster;
    [SerializeField] GameObject cueImage;

	// Update is called once per frame
	void Update () {
        if(eyeRayCaster.CurrentInteractible != null)
        {
            cueImage.SetActive(true);
        }
        else
        {
            cueImage.SetActive(false);
        }
	}
}
