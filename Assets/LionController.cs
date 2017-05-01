using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionController : MonoBehaviour {
    [SerializeField] Inventory playerInventory;
    [SerializeField] MessageController messageController;
    [SerializeField] GameObject lionKey;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character" && playerInventory.HasItem(lionKey))
        {
            messageController.SetMessage(messageController.message4);
        }
    }
}
