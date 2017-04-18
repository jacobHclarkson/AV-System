using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class FireColor : MonoBehaviour {

    [SerializeField] Light lights;
    [SerializeField] ParticleSystem flames;
    [SerializeField] ParticleSystem sparks;
    [SerializeField] private VRInteractiveItem m_Item;
    [SerializeField] GameObject fireObject;
    [SerializeField] ProximityChecker proximityChecker;


    Color[] colorArray = { Color.red, Color.green, Color.yellow};
    int current = 1;
	// Use this for initialization
	void Start () {
        SetColor(Color.green);
	}
	
	// Update is called once per frame
	void Update () {
        if(proximityChecker.inProximity && !fireObject.activeSelf && m_Item.IsOver && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
        {
            fireObject.SetActive(true);
        }
        if (fireObject.activeSelf && m_Item.IsOver && (Input.GetButtonDown("A Button") || Input.GetButtonDown("Jump")))
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
        SetColor(colorArray[current]);
    }

    void SetColor(Color c)
    {
        lights.color = flames.startColor = sparks.startColor = c;
    }
}
