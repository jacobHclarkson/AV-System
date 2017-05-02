using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDragonStatue : MonoBehaviour {

    [SerializeField] ProximityChecker prox;
    [SerializeField] MeshRenderer rend;
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject dragonIdol;
    [SerializeField] MessageController messageController;


    private bool placed = false;
	
	// Update is called once per frame
	void Update () {
        if (!placed)
        {
            if (prox.inProximity && playerInventory.HasItem(dragonIdol))
            {
                messageController.SetAVCue(true);
                rend.enabled = true;
                placed = true;
            }
            if (prox.inProximity && !playerInventory.HasItem(dragonIdol))
            {
                messageController.SetMessage(messageController.message8);
            }
        }		
	}
}
