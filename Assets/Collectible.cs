using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    [SerializeField] ProximityChecker proxCheck;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem interactiveItem;
    [SerializeField] Inventory inventory;

    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (proxCheck.inProximity && interactiveItem.IsOver && (Input.GetButtonDown("Jump") || Input.GetButtonDown("A Button")))
        {
            inventory.hasLionKey = true;
            rend.enabled = false;
        }	
	}
}
