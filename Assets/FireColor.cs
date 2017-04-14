using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class FireColor : MonoBehaviour {

    [SerializeField] Light lights;
    [SerializeField] ParticleSystem flames;
    [SerializeField] ParticleSystem sparks;
    [SerializeField] private VRInteractiveItem m_Item;

    Color[] colorArray = { Color.red, Color.green, Color.yellow };
    int current = 0;
	// Use this for initialization
	void Start () {
        Debug.Log(colorArray.Length);
        	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Item.IsOver && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            // cycle color of light, flame, and sparks
            CycleColors();
        }
	}

    void CycleColors()
    {
        current++;
        if(current > colorArray.Length - 1)
        {
            current = 0;
        }
        lights.color = colorArray[current];
        flames.startColor = colorArray[current];
        sparks.startColor = colorArray[current];
    }
}
