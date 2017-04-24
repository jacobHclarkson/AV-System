using UnityEngine;
using System.Collections;

public class LevelOneController : MonoBehaviour {

    [SerializeField] Light lightOne;
    [SerializeField] Light lightTwo;
    [SerializeField] Light lightThree;
    [SerializeField] Light lightFour;
    [SerializeField] GameObject door;

    bool roomOneSolved = false;
    bool allLightsOn = false;

	void Update () {
        if (!allLightsOn)
        {
            allLightsOn = LightsOn();
        }
        if (!roomOneSolved)
        {
            CheckLights();
        }

        if(roomOneSolved && door.transform.eulerAngles.y < 180.0f)
        {
            door.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }
	}

    void CheckLights()
    {
        if (lightOne.color == Color.green &&
            lightTwo.color == Color.red &&
            lightThree.color == Color.yellow &&
            lightFour.color == Color.green &&
            allLightsOn)
        {
            roomOneSolved = true;
        }
    }

    bool LightsOn()
    {
        if (lightOne.isActiveAndEnabled &&
            lightTwo.isActiveAndEnabled &&
            lightThree.isActiveAndEnabled &&
            lightFour.isActiveAndEnabled)
        {
            return true;
        }
        else return false;
    }
}
