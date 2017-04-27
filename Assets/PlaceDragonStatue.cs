using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDragonStatue : MonoBehaviour {

    [SerializeField] ProximityChecker prox;
    [SerializeField] MeshRenderer rend;
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject dragonIdol;


    private bool placed = false;
	
	// Update is called once per frame
	void Update () {
        if (!placed)
        {
            if (prox.inProximity && playerInventory.HasItem(dragonIdol))
            {
                rend.enabled = true;
                placed = true;
            }
        }		
	}
}
