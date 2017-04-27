using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour {
    [SerializeField] GameObject gate1;
    [SerializeField] GameObject gate2;
    [SerializeField] PressurePlate pressurePlate1;
    [SerializeField] PressurePlate pressurePlate2;

	void Update () {
        if(gate1.transform.position.y >= pressurePlate1.gateStartPosition.y + 3.5 && gate2.transform.position.y >= pressurePlate2.gateStartPosition.y + 3.5)
        {
            pressurePlate1.solved = true;
            pressurePlate2.solved = true; 
        }
	}
}
