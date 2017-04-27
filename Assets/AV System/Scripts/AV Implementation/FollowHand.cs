using UnityEngine;
using System.Collections;
using Leap;
using System;
using Leap.Unity;

public class FollowHand : MonoBehaviour {
    public string handedness;

    // target set to main camera so that view ports face you all the time
    public Transform target;

    // used to get position in game coordinates of the hand
    public GameObject hand;
    Transform handPosition;

    // using fancy leap api stuff....
    public Controller controller;
    Frame frame;

    // enable disable renderer depending on whether hands are detected
    //MeshRenderer renderer;

    // Use this for initialization
    void Start () {
        controller = new Controller();
        transform.position = new Vector3(-1000, -1000, -1000);
    }

    // Update is called once per frame
    void Update () {
        // get most recent frame from leap
        frame = controller.Frame();

        // check for hands
        if (frame.Hands.Count > 0)
        {
            for(int i=0; i<frame.Hands.Count; i++)
            {
                if((handedness.Equals("Left") && frame.Hands[i].IsLeft) || (handedness.Equals("Right") && frame.Hands[i].IsRight))
                {
                    // enable renderer for viewport and move viewport over the hand
                    handPosition = hand.transform;
                    transform.position = new Vector3(handPosition.transform.position.x, handPosition.transform.position.y, handPosition.transform.position.z);

                    // rotate viewport to always face the camera
                    transform.LookAt(target);
                    transform.RotateAround(transform.position, transform.up, 180f);
                }
            }
        }
        else
        {
            // if no hands, disable renderer and move away
            transform.position = new Vector3(-1000, -1000, -1000);
        }
	}
}
