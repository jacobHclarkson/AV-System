using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour {
    [SerializeField] Inventory playerInventory;
    [SerializeField] MessageController messageController;
    [SerializeField] GameObject lionKey;
    [SerializeField] GameObject gate1;
    [SerializeField] GameObject gate2;
    [SerializeField] PressurePlate pressurePlate1;
    [SerializeField] PressurePlate pressurePlate2;

    bool solved = false;

	void Update () {
        if(gate1.transform.position.y >= pressurePlate1.gateStartPosition.y + 3.5 && gate2.transform.position.y >= pressurePlate2.gateStartPosition.y + 3.5)
        {
            pressurePlate1.solved = true;
            pressurePlate2.solved = true; 
        }

        if (playerInventory.HasItem(lionKey) && !solved)
        {
            solved = true;
            messageController.SetMessage(messageController.message3);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character" && !playerInventory.HasItem(lionKey))
        {
            messageController.SetMessage(messageController.message2);
        }
    }
}
