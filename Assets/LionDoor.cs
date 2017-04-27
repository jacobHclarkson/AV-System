using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionDoor : MonoBehaviour {
    [SerializeField] ProximityChecker prox;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem vrItem;
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject key;

    private float originalRotation;
    bool unlocked = false;
    float moved = 0;
    // 296 = 0
    void Start()
    {
        originalRotation = transform.rotation.eulerAngles.y;
        Debug.Log(originalRotation);
    }

	// Update is called once per frame
	void Update () {
	    if(prox.inProximity && vrItem.IsOver && playerInventory.hasLionKey && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            unlocked = true;
            key.SetActive(true);
        }

        if (unlocked)
        {
            CalcMoved();
            if(moved <= 90)
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 20);
            }
        }
	}

    void CalcMoved()
    {
        moved = (transform.rotation.eulerAngles.y - originalRotation);
        if (moved < 0)
        {
            moved += 360;
        }
    }
}
