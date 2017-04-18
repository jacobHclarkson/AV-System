using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class PickUp : MonoBehaviour {

    [SerializeField] VRInteractiveItem item;
    [SerializeField] Camera mainCamera;
    [SerializeField] ProximityChecker proximityChecker;

    bool holding = false;

    float minHoldTime = 0.05f;

    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	void Update () {
        if (proximityChecker.inProximity && item.IsOver && !holding && Input.GetButtonDown("Jump") || Input.GetButtonDown("A Button"))
        {
            transform.parent = mainCamera.transform;
            rb.isKinematic = true;
            holding = true;
        }

        if (holding)
        {
            minHoldTime -= Time.deltaTime;
        }

        if(holding && minHoldTime <= 0.0f && Input.GetButtonDown("Jump") || Input.GetButtonDown("A Button"))
        {
            transform.parent = null;
            rb.isKinematic = false;
            holding = false;
            minHoldTime = 0.05f;
        }
	}
}
