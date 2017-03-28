using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class Button : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_Item;
    [SerializeField] private Collideable col;
    public Color startColor;

    Vector3 startPosition;
    Vector3 pushedPosition;

    public bool pushed = false;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        pushedPosition = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
        GetComponent<Renderer>().material.color = startColor;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_Item.IsOver && Input.GetButtonDown("A Button") && col.triggered)
        {
            pushed = true;

            // change color
            GetComponent<Renderer>().material.color = Color.green;

            // move down
            transform.position = pushedPosition;
        }

	}
}
