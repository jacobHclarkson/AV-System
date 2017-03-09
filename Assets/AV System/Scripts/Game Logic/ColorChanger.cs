using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ColorChanger : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_Item;



	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Item.IsOver)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
	}
}
