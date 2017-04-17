using UnityEngine;
using System.Collections;

public class LevelOneController : MonoBehaviour {

    [SerializeField] Light lightOne;
    [SerializeField] Light lightTwo;
    [SerializeField] Light lightThree;
    [SerializeField] Light lightFour;
    [SerializeField] GameObject door;

    bool roomOneSolved = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!roomOneSolved)
        {
            CheckLights();
        }

        // rotate door
        if(roomOneSolved && door.transform.eulerAngles.y < 180.0f)
        {
            door.transform.Rotate(Vector3.up * Time.deltaTime * 10);
        }
	}

    void CheckLights()
    {
        if (lightOne.color == Color.green &&
            lightTwo.color == Color.green &&
            lightThree.color == Color.green &&
            lightFour.color == Color.green)
        {
            roomOneSolved = true;
        }
    }
}
