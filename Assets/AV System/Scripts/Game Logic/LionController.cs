using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionController : MonoBehaviour {
    [SerializeField] Inventory playerInventory;
    [SerializeField] MessageController messageController;
    [SerializeField] GameObject lionKey;
    [SerializeField] GameObject dragonIdol;

    bool solved = false;

    void Update()
    {
        if (playerInventory.HasItem(dragonIdol) && !solved)
        {
            solved = true;
            Debug.Log("picked up dragon idol");
            messageController.SetMessage(messageController.message6); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character" && playerInventory.HasItem(lionKey))
        {
            messageController.SetMessage(messageController.message4);
        }
    }
}
