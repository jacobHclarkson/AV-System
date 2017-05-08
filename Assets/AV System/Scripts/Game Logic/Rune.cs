using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour {

    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem vrItem;
    [SerializeField] ProximityChecker prox;
    [SerializeField] GameObject displayPlane;
    [SerializeField] LionController lionController;

    public bool activated = false;

    Color startColor;

    void Start()
    {
        startColor = displayPlane.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if(vrItem.IsOver && prox.inProximity && activated == true && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            lionController.currentAttempt.Clear();
            lionController.DeactivateAll();
        }else
        if(vrItem.IsOver && prox.inProximity && activated == false && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            lionController.currentAttempt.Add(gameObject);
            GetComponent<AudioSource>().Play();
            ToggleActive();
        }
        if (activated)
        {
            displayPlane.GetComponent<Renderer>().material.color = Color.green;
        }else
        {
            displayPlane.GetComponent<Renderer>().material.color = startColor;
        }
    }

    void ToggleActive()
    {
        activated = !activated;
    }

}
