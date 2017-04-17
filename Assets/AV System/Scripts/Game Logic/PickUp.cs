using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class PickUp : MonoBehaviour {

    [SerializeField] VRInteractiveItem item;
    [SerializeField] Camera mainCamera;

    bool holding = false;

    float minHoldTime = 0.05f;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (item.IsOver && !holding && Input.GetButtonDown("Jump"))
        {
            transform.parent = mainCamera.transform;
            rb.isKinematic = true;
            holding = true;
        }

        if (holding)
        {
            minHoldTime -= Time.deltaTime;
        }

        if(holding && minHoldTime <= 0.0f && Input.GetButtonDown("Jump"))
        {
            transform.parent = null;
            rb.isKinematic = false;
            holding = false;
            minHoldTime = 0.05f;
        }
	}
}
