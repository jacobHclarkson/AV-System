using UnityEngine;
using System.Collections;

public class LevelTwoController : MonoBehaviour {
    [SerializeField] GameObject gate;
    [SerializeField] TableColliderCheck horseTable;
    [SerializeField] TableColliderCheck dragonTable;
    [SerializeField] TableColliderCheck lionTable;
    [SerializeField] MessageController messageController;
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject dragonIdol;
    [SerializeField] GameObject dragonStatue;
    [SerializeField] AudioClip dragonLanding;
    [SerializeField] AudioClip dragonRoar0;
    [SerializeField] AudioClip dragonRoar1;
    [SerializeField] AudioClip dragonWings;
    [SerializeField] VRStandardAssets.Utils.VRCameraFade fader;


    public bool solved = false;
    bool ending = false;
    Vector3 gateStartPos;

    void Start()
    {
        gateStartPos = gate.transform.position;
    }
	
	void Update () {
        if (!solved)
        {
            CheckSolution();
        }else
        {
            if (!ending)
            {
                ending = true;
                PlayEnding();
            }
        }
	}

    void CheckSolution()
    {
        if(horseTable.objectPlaced && dragonTable.objectPlaced && lionTable.objectPlaced)
        {
            solved = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character" && playerInventory.HasItem(dragonIdol))
        {
            messageController.SetMessage(messageController.message7);
        }
    }

    void PlayEnding()
    {
        // make dragon dissapear
        dragonStatue.GetComponentInChildren<MeshRenderer>().enabled = false;

        // play noises
        dragonStatue.GetComponent<AudioSource>().PlayOneShot(dragonLanding);
        dragonStatue.GetComponent<AudioSource>().PlayOneShot(dragonRoar0);
        dragonStatue.GetComponent<AudioSource>().PlayOneShot(dragonRoar1);
        dragonStatue.GetComponent<AudioSource>().PlayOneShot(dragonWings);

        fader.FadeOut(10, false);
    }
}
