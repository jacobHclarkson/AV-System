using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractiveCue : MonoBehaviour {

    [SerializeField] VRStandardAssets.Utils.VREyeRaycaster eyeRayCaster;
    [SerializeField] GameObject cueImage;
    [SerializeField] Image reticule;

    Color startColor;

    void Start()
    {
        startColor = cueImage.GetComponent<Image>().color;
    }

	void Update () {
        if(eyeRayCaster.CurrentInteractible != null)
        {
            cueImage.SetActive(true);
            if (eyeRayCaster.CurrentInteractible.GetComponent<ProximityChecker>().inProximity)
            {
                cueImage.GetComponent<Image>().color = Color.green;
                reticule.color = Color.green;
            }
            else
            {
                cueImage.GetComponent<Image>().color = startColor;
                reticule.color = startColor;
            }
        }
        else
        {
            cueImage.GetComponent<Image>().color = Color.green;
            cueImage.SetActive(false);
            reticule.color = startColor;
        }
	}
}
