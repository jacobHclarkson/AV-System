using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionDoor : MonoBehaviour {
    [SerializeField] ProximityChecker prox;
    [SerializeField] VRStandardAssets.Utils.VRInteractiveItem vrItem;
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject key;
    [SerializeField] GameObject lionKey;
    [SerializeField] MessageController messageController;

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
	    if(prox.inProximity && vrItem.IsOver && playerInventory.HasItem(lionKey) && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            unlocked = true;
            key.SetActive(true);
            GetComponent<AudioSource>().Play();
            messageController.SetAVCue(true);
        }

	    if(prox.inProximity && vrItem.IsOver && !playerInventory.HasItem(lionKey) && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            messageController.SetMessage(messageController.message5);
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
