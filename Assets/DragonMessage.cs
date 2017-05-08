using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMessage : MonoBehaviour {

    [SerializeField] GameObject dragonIdol;
    [SerializeField] Inventory playerInventory;
    [SerializeField] MessageController messageController;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character" && playerInventory.HasItem(dragonIdol))
        {
            messageController.SetMessage("Look inside the envelope.");
            messageController.SetAVCue(true);
        }
    }
}
