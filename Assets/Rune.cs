using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour {

    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem vrItem;
    [SerializeField] ProximityChecker prox;
    [SerializeField] GameObject displayPlane;

    public bool active = false;

    Color startColor;

    void Start()
    {
        startColor = displayPlane.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        // if player close and presses A
        if(vrItem.IsOver && prox.inProximity && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            // play sound
            ToggleActive();
        }

        if (active)
        {
            // glow
            displayPlane.GetComponent<Renderer>().material.color = Color.green;
        }else
        {
            displayPlane.GetComponent<Renderer>().material.color = startColor;
        }
    }

    void ToggleActive()
    {
        active = !active;
    }

}
